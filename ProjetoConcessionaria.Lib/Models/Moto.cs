using ProjetoConcessionaria.Lib.Exceptions;

namespace ProjetoConcessionaria.Lib.Models
{
    public class Moto : Veiculo
    {
        private int Cilindrada { get; set; }
        private string Partida { get; set; }

        public Moto(string marca, string modelo, DateTime ano, int quilometragem, string cor, double valor,
                     int cilindrada, string partida) : base(marca, modelo, ano, quilometragem, cor, valor)
        {
            SetCilindrada(cilindrada);
            SetPartida(partida);
        }

        public void SetCilindrada(int cilindrada)
        {
            Cilindrada = cilindrada;
        }
        public int GetCilindrada()
        {
            return Cilindrada;
        }
        public void SetPartida(string partida)
        {
            Partida = partida;
        }
        public string GetPartida()
        {
            return Partida;
        }
        public virtual double CalcValor(double valor)
        {
            valor = Valor + (Cilindrada * 50);
            if (Partida == "Eletronica")
            {
                return Valor = valor * 1.1;
            }
            return Valor = valor;
        }

        public override bool ValidarValor(double valor)
        {
            if (valor >= 2000)
                return true;
            throw new ErroDeValidacaoException("Valor de moto tem que ser maior que 2000!");
        }

    }
}