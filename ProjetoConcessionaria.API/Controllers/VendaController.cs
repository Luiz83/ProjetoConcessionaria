using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;

namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class VendaController : ControllerBase
{
    public static List<VendaDto> VendasDaClasse { get; set; } = new List<VendaDto>();

     public ILogger<VendaController> Log { get; set; }

    public VendaController(ILogger<VendaController> log)
    {
        Log = log;
    }

    [HttpPost("SetVenda")]
    public IActionResult SetVenda(VendaDto vendaDto)
    {
        try
        {
            var venda = new Venda(vendaDto.ClienteDto, vendaDto.VendedorDto, vendaDto.VeiculoDto, vendaDto.FormaPagamento, vendaDto.ValorFinal);
            VendasDaClasse.Add(vendaDto);
            return Ok(VendasDaClasse);
        }
        catch (ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetVenda")]
    public IActionResult GetVenda()
    {
        return Ok(VendasDaClasse);
    }

    [HttpDelete("DeleteVenda")]
    public IActionResult DeleteVenda()
    {
        var index = VendasDaClasse.Count();
        if (index != 0)
        {
            VendasDaClasse.RemoveAt(index - 1);
            return Ok(VendasDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}