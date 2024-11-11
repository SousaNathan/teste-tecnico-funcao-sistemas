﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        public long Id { get; set; }
        
        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        public string CEP
        {
            get => _cep;
            set => _cep = RemoveSpecialChars(value);
        }
        private string _cep;

        /// <summary>
        /// CPF
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Digite um CPF válido")]
        public string CPF
        {
            get => _cpf;
            set => _cpf = RemoveSpecialChars(value);
        }
        private string _cpf;

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone
        {
            get => _telefone;
            set => _telefone = RemoveSpecialChars(value);
        }
        private string _telefone;

        /// <summary>
        /// Lista de Beneficiários associados ao Cliente
        /// </summary>
        public ICollection<BeneficiarioModel> Beneficiarios { get; set; } = new List<BeneficiarioModel>();

        private string RemoveSpecialChars(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return new string(value.Where(char.IsDigit).ToArray());
        }
    }    
}