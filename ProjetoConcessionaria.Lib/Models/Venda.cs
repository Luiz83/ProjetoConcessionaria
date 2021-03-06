namespace ProjetoConcessionaria.Lib.Models
{
    public class Venda
    {
        private Cliente Cliente { get; set; }
        private Funcionario Vendedor { get; set; }
        private Veiculo Veiculo { get; set; }
        private string FormaPagamento { get; set; }
        private double ValorFinal { get; set; }

        public Venda(Cliente cliente, Funcionario vendedor, Veiculo veiculo, string formaPagamento, double valorFinal)
        {
            SetCliente(cliente);
            SetVendedor(vendedor);
            SetVeiculo(veiculo);
            SetFormaPagamento(formaPagamento);
            SetValorFinal(valorFinal);
        }

        public void SetCliente(Cliente cliente)
        {
            Cliente = cliente;
        }
        public Cliente GetCliente()
        {
            return Cliente;
        }
        public void SetVendedor(Funcionario vendedor)
        {
            Vendedor = vendedor;
        }
        public Funcionario GetVendedor()
        {
            return Vendedor;
        }
        public void SetVeiculo(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }
        public Veiculo GetVeiculo()
        {
            return Veiculo;
        }
        public void SetFormaPagamento(string formaPagamento)
        {
            FormaPagamento = formaPagamento;
        }
        public string GetFormaPagamento()
        {
            return FormaPagamento;
        }
        public void SetValorFinal(double valorFinal)
        {
            ValorFinal = valorFinal;
        }
        public double GetValorFinal()
        {
            return ValorFinal;
        }
        public void AplicarDesconto()
        {
            if (Vendedor.GetCargo() == "Gerente")
            {
                ValorFinal = ValorFinal * 0.95;
            }
        }
    }
}