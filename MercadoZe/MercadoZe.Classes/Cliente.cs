using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoZe.Domain
{
    public class Cliente
    {
        public int ID { get; set; }
        public int CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int PontosFidelidade { get; set; }
        public Endereco endereco { get; set; }

        public override string ToString()
        {
            return $"CPF: {CPF}, Nome: {Nome}, Data de Nascimento {DataNascimento}, Pontos de fidelidade: {PontosFidelidade}, Rua: {endereco.Rua}, Numero: {endereco.Numero}, Bairro: {endereco.bairro}, Cep: {endereco.Cep}, Complemento: {endereco.Complemento} ";
        }
    }
}
