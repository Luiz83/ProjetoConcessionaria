using ProjetoConcessionaria.Lib.Exceptions;

namespace ProjetoConcessionaria.Lib.Models
{
    public class Veiculo
    {
        private string Marca { get; set; }
        private string Modelo { get; set; }
        private DateTime Ano { get; set; }
        private int Quilometragem { get; set; }
        private string Cor { get; set; }
        protected double Valor { get; set; }

        public Veiculo(string marca, string modelo, DateTime ano, int quilometragem, string cor, double valor)
        {
            SetMarca(marca);
            SetModelo(modelo);
            SetAno(ano);
            SetQuilometragem(quilometragem);
            SetCor(cor);
            SetValor(valor);
        }

        public void SetMarca(string marca)
        {
            Marca = marca;
        }

        public string GetMarca()
        {
            return Marca;
        }
        public void SetModelo(string modelo)
        {
            Modelo = modelo;
        }

        public string GetModelo()
        {
            return Modelo;
        }
        public void SetAno(DateTime ano)
        {
            ValidarAno(ano);
            Ano = ano;
        }
        public DateTime GetAno()
        {
            return Ano;
        }
        public void SetQuilometragem(int quilometragem)
        {
            Quilometragem = quilometragem;
        }
        public int GetQuilometragem()
        {
            return Quilometragem;
        }
        public void SetCor(string cor)
        {
            Cor = cor;
        }
        public string GetCor()
        {
            return Cor;
        }
        public void SetValor(double valor)
        {
            ValidarValor(valor);
            Valor = valor;
        }
        public double GetValor()
        {
            return Valor;
        }

        public virtual double CalcValor()
        {
            return Valor;
        }

        public bool ValidarAno(DateTime ano)
        {
            var data = ano;
            if (data >= DateTime.Parse("01/01/2004") && data < DateTime.Now)
                return true;
            throw new ErroDeValidacaoException("Ano do carro tem que ser entre 2004 e o ano atual!");
        }

        public virtual bool ValidarValor(double valor)
        {
            return true;
        }
    }
}