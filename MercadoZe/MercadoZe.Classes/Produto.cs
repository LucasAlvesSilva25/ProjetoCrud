using System;

namespace MercadoZe.Domain
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set; }
        public int QuantidadeEstoque { get; set; }

        public override string ToString()
        {
            return $"ID:{ID}, Nome: {Nome}, Descrição: {Descricao}, Data vencimento: {DataVencimento}, Preço unitário: {PrecoUnitario}, Unidade: {Unidade}, Quantidade estoque: {QuantidadeEstoque}";
        }


    }
}
