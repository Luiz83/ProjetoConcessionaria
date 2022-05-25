using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;


namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class MotoController : ControllerBase
{
    public static List<MotoDto> MotosDaClasse { get; set; } = new List<MotoDto>();

    public ILogger<MotoController> Log { get; set; }

    public MotoController(ILogger<MotoController> log)
    {
        Log = log;
    }

    [HttpPost("SetMoto")]
    public IActionResult SetMoto(MotoDto motoDto)
    {
        try
        {
            var moto = new Moto(motoDto.Marca, motoDto.Modelo, motoDto.Ano, motoDto.Quilometragem, motoDto.Cor, motoDto.Valor, motoDto.Cilindrada, motoDto.Partida);
            MotosDaClasse.Add(motoDto);
            return Ok(MotosDaClasse);
        }
        catch (ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetMoto")]
    public IActionResult GetMoto()
    {
        return Ok(MotosDaClasse);
    }

    [HttpDelete("DeleteMoto")]
    public IActionResult DeleteMoto()
    {
        var index = MotosDaClasse.Count();
        if (index != 0)
        {
            MotosDaClasse.RemoveAt(index - 1);
            return Ok(MotosDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}