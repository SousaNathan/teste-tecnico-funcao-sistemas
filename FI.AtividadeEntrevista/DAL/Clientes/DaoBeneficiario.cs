using System.Collections.Generic;
using System.Data;

namespace FI.AtividadeEntrevista.DAL
{
    /// <summary>
    /// Classe de acesso a dados de Beneficiário
    /// </summary>
    internal class DaoBeneficiario : AcessoDados
    {
        /// <summary>
        /// Consulta todos os beneficiários de um cliente específico
        /// </summary>
        /// <param name="idCliente">ID do cliente</param>
        /// <returns>Lista de beneficiários</returns>
        internal List<DML.Beneficiario> Consultar(long idCliente)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>
            {
                new System.Data.SqlClient.SqlParameter("IdCliente", idCliente)
            };

            DataSet ds = base.Consultar("FI_SP_ConsBeneficiarios", parametros);

            return Converter(ds);
        }

        /// <summary>
        /// Inclui todos os beneficiários de um cliente
        /// </summary>
        /// <param name="beneficiarios">Lista de beneficiários a serem cadastrados</param>
        internal void Incluir(List<DML.Beneficiario> beneficiarios)
        {
            foreach (var beneficiario in beneficiarios)
            {
                List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>
                {
                    new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome),
                    new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF),
                    new System.Data.SqlClient.SqlParameter("IdCliente", beneficiario.IdCliente)
                };

                base.Executar("FI_SP_IncBeneficiario", parametros);
            }
        }

        /// <summary>
        /// Exclui todos os beneficiários de um cliente específico
        /// </summary>
        internal void Excluir(long idCliente)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>
            {
                new System.Data.SqlClient.SqlParameter("IdCliente", idCliente)
            };

            base.Executar("FI_SP_DelBeneficiarios", parametros);
        }

        /// <summary>
        /// Converte o DataSet em uma lista de Beneficiarios
        /// </summary>
        private List<DML.Beneficiario> Converter(DataSet ds)
        {
            List<DML.Beneficiario> lista = new List<DML.Beneficiario>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Beneficiario benef = new DML.Beneficiario
                    {
                        Id = row.Field<long>("Id"),
                        Nome = row.Field<string>("Nome"),
                        CPF = row.Field<string>("CPF"),
                        IdCliente = row.Field<long>("IdCliente")
                    };
                    lista.Add(benef);
                }
            }

            return lista;
        }
    }
}
