using System;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.Lib.Models;
using Xunit;
namespace ProjetoConcessionaria.TesteUnitario;

public class CarroTest
{

    [Fact]
    public void TestarGetESetDeTransmissaoAutomatica()
    {
        //Arrange
        var valorEsperado = false;
        var veiculo = CriarCarroPadrao();

        //Act
        veiculo.SetTransmissaoAutomatica(valorEsperado);
        var valorAtual = veiculo.GetTransmissaoAutomatica();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarGetESetDeCombustivel()
    {
        //Arrange
        var valorEsperado = "Alcool";
        var veiculo = CriarCarroPadrao();

        //Act
        veiculo.SetCombustivel(valorEsperado);
        var valorAtual = veiculo.GetCombustivel();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarSeCalcValorFuncionaCorretamente()
    {
        //Arrange
        var valorEsperado = 6000;
        var veiculo = CriarCarroPadrao();

        //Act
        var valorAtual = veiculo.CalcValor();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void CarroNaoPodeTerValorMenorQue5000()
    {
        //Arrange
        var valorEsperado = 4000;
        var veiculo = CriarCarroPadrao();

        //Act e Assert
        var exception = Assert.Throws<ErroDeValidacaoException>(() => veiculo.SetValor(valorEsperado));
        Assert.Equal("Valor de carro tem que ser maior que 5000!", exception.Message);
    }

    public Carro CriarCarroPadrao()
    {
        return new Carro("Teste", "Teste", DateTime.Now, 0, "Vermelho", 5000, true, "Gasolina");
    }

}