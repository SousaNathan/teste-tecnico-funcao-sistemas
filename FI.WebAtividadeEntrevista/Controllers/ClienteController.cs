using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModel model)
        {
            BoCliente boCliente = new BoCliente();
            BoBeneficiario boBeneficiario = new BoBeneficiario();

            if (boCliente.VerificarExistencia(model.CPF, model.Email))
            {
                Response.StatusCode = 400;
                return Json("Já existe um cliente cadastrado com este CPF e/ou E-mail.");
            }

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;

                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                model.Id = boCliente.Incluir(new Cliente()
                {
                    CEP = model.CEP.ToUpper(),
                    CPF = model.CPF.ToUpper(),
                    Cidade = model.Cidade.ToUpper(),
                    Email = model.Email.ToUpper(),
                    Estado = model.Estado.ToUpper(),
                    Logradouro = model.Logradouro.ToUpper(),
                    Nacionalidade = model.Nacionalidade.ToUpper(),
                    Nome = model.Nome.ToUpper(),
                    Sobrenome = model.Sobrenome.ToUpper(),
                    Telefone = model.Telefone.ToUpper()
                });

                if (model.Beneficiarios != null && model.Beneficiarios.Any())
                {
                    var beneficiarios = model.Beneficiarios.Select(b => new Beneficiario
                    {
                        Nome = b.Nome.ToUpper(),
                        CPF = b.CPF.ToUpper(),
                        IdCliente = model.Id
                    }).ToList();

                    boBeneficiario.Incluir(beneficiarios);
                }

                return Json("Cadastro efetuado com sucesso!");
            }
        }

        [HttpPost]
        public JsonResult Alterar(ClienteModel model)
        {
            BoCliente boCliente = new BoCliente();
            BoBeneficiario boBeneficiario = new BoBeneficiario();

            bool clienteExistente = boCliente.VerificarExistenciaAlterar(model.CPF, model.Email, model.Id);

            if (clienteExistente )
            {
                Response.StatusCode = 400;
                return Json("Já existe um cliente cadastrado com este CPF e/ou E-mail.");
            }

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;

                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                boCliente.Alterar(new Cliente()
                {
                    Id = model.Id,
                    CEP = model.CEP.ToUpper(),
                    CPF = model.CPF.ToUpper(),
                    Cidade = model.Cidade.ToUpper(),
                    Email = model.Email.ToUpper(),
                    Estado = model.Estado.ToUpper(),
                    Logradouro = model.Logradouro.ToUpper(),
                    Nacionalidade = model.Nacionalidade.ToUpper(),
                    Nome = model.Nome.ToUpper(),
                    Sobrenome = model.Sobrenome.ToUpper(),
                    Telefone = model.Telefone.ToUpper()
                });

                boBeneficiario.Excluir(model.Id);

                if (model.Beneficiarios != null && model.Beneficiarios.Any())
                {
                    var beneficiarios = model.Beneficiarios.Select(b => new Beneficiario
                    {
                        Nome = b.Nome.ToUpper(),
                        CPF = b.CPF.ToUpper(),
                        IdCliente = model.Id
                    }).ToList();

                    boBeneficiario.Incluir(beneficiarios);
                }

                return Json("Cliente alterado com sucesso!");
            }
        }


        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoCliente boCliente = new BoCliente();
            BoBeneficiario boBeneficiario = new BoBeneficiario();
            Cliente cliente = boCliente.Consultar(id);
            ClienteModel model = null;

            if (cliente != null)
            {
                model = new ClienteModel()
                {
                    Id = cliente.Id,
                    CEP = cliente.CEP,
                    CPF = cliente.CPF,
                    Cidade = cliente.Cidade,
                    Email = cliente.Email,
                    Estado = cliente.Estado,
                    Logradouro = cliente.Logradouro,
                    Nacionalidade = cliente.Nacionalidade,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Telefone = cliente.Telefone,
                    Beneficiarios = boBeneficiario.Consultar(cliente.Id).Select(b => new BeneficiarioModel
                    {
                        Nome = b.Nome,
                        CPF = b.CPF
                    }).ToList()
                };
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Excluir(long id)
        {
            try
            {
                BoCliente boCliente = new BoCliente();
                BoBeneficiario boBeneficiario = new BoBeneficiario();

                boBeneficiario.Excluir(id);
                boCliente.Excluir(id);

                return Json(new { Result = "OK", Message = "Cliente excluído com sucesso!" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Cliente> clientes = new BoCliente().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}
