using System;
using ProjetoConcessionaria.Lib.Models;
using Xunit;
namespace ProjetoConcessionaria.TesteUnitario;

public class VendaTest
{
    [Fact]
    public void TestarGetESetDeCliente()
    {
        //Arrange
        var carroParametro = CriarCarroPadrao();
        var vendedorParametro = CriarVendedorPadrao();
        var valorEsperado = CriarClientePadrao();
        var venda = new Venda(valorEsperado, vendedorParametro, carroParametro, "1", 1);

        //Act
        var valorAtual = venda.GetCliente();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }
    [Fact]
    public void TestarGetESetDeVendedor()
    {
        //Arrange
        var carroParametro = CriarCarroPadrao();
        var valorEsperado = CriarVendedorPadrao();
        var clienteParametro = CriarClientePadrao();
        var venda = new Venda(clienteParametro, valorEsperado, carroParametro, "1", 1);

        //Act
        var valorAtual = venda.GetVendedor();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarGetESetDeVeiculo()
    {
        //Arrange
        var valorEsperado = CriarCarroPadrao();
        var vendedorParametro = CriarVendedorPadrao();
        var clienteParametro = CriarClientePadrao();
        var venda = new Venda(clienteParametro, vendedorParametro, valorEsperado, "1", 1);

        //Act
        var valorAtual = venda.GetVeiculo();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarGetESetDeFormaPagamento()
    {
        //Arrange
        var carroParametro = CriarCarroPadrao();
        var vendedorParametro = CriarVendedorPadrao();
        var clienteParametro = CriarClientePadrao();
        var valorEsperado = "Debito";
        var venda = new Venda(clienteParametro, vendedorParametro, carroParametro, valorEsperado, 1);

        //Act
        var valorAtual = venda.GetFormaPagamento();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarGetESetDeValorFInal()
    {
        //Arrange
        var carroParametro = CriarCarroPadrao();
        var vendedorParametro = CriarVendedorPadrao();
        var clienteParametro = CriarClientePadrao();
        var valorEsperado = 6000;
        var venda = new Venda(clienteParametro, vendedorParametro, carroParametro, "1", valorEsperado);

        //Act
        var valorAtual = venda.GetValorFinal();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    [Fact]
    public void TestarSeAplicarDescontoFuncionaCorretamente()
    {
        //Arrange
        var carroParametro = CriarCarroPadrao();
        var vendedorParametro = CriarVendedorPadrao();
        var clienteParametro = CriarClientePadrao();
        vendedorParametro.SetCargo("Gerente");
        var valorEsperado = 95;
        var venda = new Venda(clienteParametro, vendedorParametro, carroParametro, "1", 100);

        //Act
        venda.AplicarDesconto();
        var valorAtual = venda.GetValorFinal();

        //Assert
        Assert.Equal(valorEsperado, valorAtual);
    }

    public Carro CriarCarroPadrao()
    {
        return new Carro("Teste", "Teste", DateTime.Parse("01/01/2022"), 0, "Vermelho", 5000, true, "Gasolina");
    }
    public Cliente CriarClientePadrao()
    {
        return new Cliente("Luiz", "444-555-444-45", "01/01/2022", "teste@gmail.com", "11944445555");
    }
    public Funcionario CriarVendedorPadrao()
    {
        return new Funcionario("Luiz", "444-555-444-45", "01/01/2022", "Vendedor");
    }

}