using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Beneficiário
    /// </summary>
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nome do Beneficiário
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF do Beneficiário
        /// </summary>
        [Required]
        public string CPF
        {
            get => _cpf;
            set => _cpf = RemoveSpecialChars(value);
        }
        private string _cpf;

        /// <summary>
        /// Id do Cliente associado
        /// </summary>
        [Required]
        public long IdCliente { get; set; }

        /// <summary>
        /// Cliente ao qual o Beneficiário está associado
        /// </summary>
        public ClienteModel Cliente { get; set; }

        private string RemoveSpecialChars(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
