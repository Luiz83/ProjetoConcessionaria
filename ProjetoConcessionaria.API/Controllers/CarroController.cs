using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;

namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class CarroController : ControllerBase
{
    public static List<CarroDto> CarrosDaClasse { get; set; } = new List<CarroDto>();

    public ILogger<CarroController> Log { get; set; }

    public CarroController(ILogger<CarroController> log)
    {
        Log = log;
    }

    [HttpPost("SetCarro")]
    public IActionResult SetCarro(CarroDto carroDto)
    {
        try
        {
            var carro = new Carro(carroDto.Marca, carroDto.Modelo, carroDto.Ano, carroDto.Quilometragem, carroDto.Cor, carroDto.Valor, carroDto.TransmissaoAutomatica, carroDto.Combustivel);
            CarrosDaClasse.Add(carroDto);
            return Ok(CarrosDaClasse);
        }
        catch (ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarro")]
    public IActionResult GetCarro()
    {
        return Ok(CarrosDaClasse);
    }

    [HttpDelete("DeleteCarro")]
    public IActionResult DeleteCarro()
    {
        var index = CarrosDaClasse.Count();
        if (index != 0)
        {
            CarrosDaClasse.RemoveAt(index - 1);
            return Ok(CarrosDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}