using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoZe.Domain
{
    public struct Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string bairro { get; set; }
        public int Cep { get; set; }
        public string Complemento { get; set; }
    }
}
