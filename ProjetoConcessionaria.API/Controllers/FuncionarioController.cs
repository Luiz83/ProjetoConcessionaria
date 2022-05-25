using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;

namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class FuncionarioController : ControllerBase
{
    public static List<FuncionarioDto> FuncionariosDaClasse { get; set; } = new List<FuncionarioDto>();

    public ILogger<FuncionarioController> Log { get; set; }

    public FuncionarioController(ILogger<FuncionarioController> log)
    {
        Log = log;
    }

    [HttpPost("SetFuncionario")]
    public IActionResult SetFuncionario(FuncionarioDto funcionarioDto)
    {
        try{
        var funcionario = new Funcionario(funcionarioDto.Nome, funcionarioDto.Cpf, funcionarioDto.DataNascimento.ToString("yyyy"), funcionarioDto.Cargo);
        FuncionariosDaClasse.Add(funcionarioDto);
        return Ok(FuncionariosDaClasse);
        }
        catch(ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetFuncionario")]
    public IActionResult GetFuncionario()
    {
        return Ok(FuncionariosDaClasse);
    }

    [HttpDelete("DeleteFuncionario")]
    public IActionResult DeleteFuncionario()
    {
        var index = FuncionariosDaClasse.Count();
        if (index != 0)
        {
            FuncionariosDaClasse.RemoveAt(index - 1);
            return Ok(FuncionariosDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}