using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Consulta todos os beneficiários de um cliente específico
        /// </summary>
        /// <param name="clienteId">Id do cliente</param>
        /// <returns>Lista de beneficiários</returns>
        public List<DML.Beneficiario> Consultar(long clienteId)
        {
            DAL.DaoBeneficiario daoBeneficiario = new DAL.DaoBeneficiario();
            return daoBeneficiario.Consultar(clienteId);
        }

        /// <summary>
        /// Inclui todos os beneficiários de um cliente
        /// </summary>
        /// <param name="beneficiarios">Lista de beneficiários</param>
        public void Incluir(List<DML.Beneficiario> beneficiarios)
        {
            DAL.DaoBeneficiario daoBeneficiario = new DAL.DaoBeneficiario();
            daoBeneficiario.Incluir(beneficiarios);
        }

        /// <summary>
        /// Exclui todos os beneficiários de um cliente específico
        /// </summary>
        /// <param name="clienteId">Id do cliente</param>
        public void Excluir(long clienteId)
        {
            DAL.DaoBeneficiario daoBeneficiario = new DAL.DaoBeneficiario();
            daoBeneficiario.Excluir(clienteId);
        }
    }
}
