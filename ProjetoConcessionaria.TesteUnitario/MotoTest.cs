using System;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.Lib.Models;
using Xunit;
namespace ProjetoConcessionaria.TesteUnitario;

public class MotoTest
{

    [Fact]
    public void TestarGetESetDeCilindrada()
    {
        //Arrange
        var valorEsperado = 250;
        var veiculo = CriarMotoPadrao();

        //Act
        veiculo.SetCilindrada(valorEsperado);
        var valorAtual = veiculo.GetCilindrada();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarGetESetDePartida()
    {
        //Arrange
        var valorEsperado = "Carburador";
        var veiculo = CriarMotoPadrao();

        //Act
        veiculo.SetPartida(valorEsperado);
        var valorAtual = veiculo.GetPartida();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarSeCalcValorFuncionaCorretamente()
    {
        //Arrange
        var valorEsperado = 35200;
        var veiculo = CriarMotoPadrao();

        //Act
        var valorAtual = veiculo.CalcValor(veiculo.GetValor());

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void CarroNaoPodeTerValorMenorQue2000()
    {
        //Arrange
        var valorEsperado = 1000;
        var veiculo = CriarMotoPadrao();

        //Act e Assert
        var exception = Assert.Throws<ErroDeValidacaoException>(() => veiculo.SetValor(valorEsperado));
        Assert.Equal("Valor de moto tem que ser maior que 2000!", exception.Message);
    }

    public Moto CriarMotoPadrao()
    {
        return new Moto("Teste", "Teste", DateTime.Now, 0, "Vermelho", 2000, 600, "Eletronica");
    }

}