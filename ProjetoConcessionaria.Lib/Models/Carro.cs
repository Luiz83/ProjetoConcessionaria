using ProjetoConcessionaria.Lib.Exceptions;

namespace ProjetoConcessionaria.Lib.Models
{
    public class Carro : Veiculo
    {
        private bool TransmissaoAutomatica { get; set; }
        private string Combustivel { get; set; }

        public Carro(string marca, string modelo, DateTime ano, int quilometragem, string cor, double valor,
                     bool transmissaoAutomatica, string combustivel) : base(marca, modelo, ano, quilometragem, cor, valor)
        {
            SetTransmissaoAutomatica(transmissaoAutomatica);
            SetCombustivel(combustivel);
        }

        public void SetTransmissaoAutomatica(bool transmissaoAutomatica)
        {
            TransmissaoAutomatica = transmissaoAutomatica;
        }
        public bool GetTransmissaoAutomatica()
        {
            return TransmissaoAutomatica;
        }
        public void SetCombustivel(string combustivel)
        {
            Combustivel = combustivel;
        }
        public string GetCombustivel()
        {
            return Combustivel;
        }
        public override double CalcValor()
        {
            if (TransmissaoAutomatica)
            {
                return Valor = Valor * 1.2;
            }
            return Valor;
        }

        public override bool ValidarValor(double valor)
        {
            if (valor >= 5000)
                return true;
            throw new ErroDeValidacaoException("Valor de carro tem que ser maior que 5000!");
        }

    }
}