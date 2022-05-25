using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;


namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PessoaController : ControllerBase
{
    public static List<PessoaDto> PessoasDaClasse { get; set; } = new List<PessoaDto>();

    public ILogger<PessoaController> Log { get; set; }

    public PessoaController(ILogger<PessoaController> log)
    {
        Log = log;
    }

    [HttpPost("SetPessoa")]
    public IActionResult SetPessoa(PessoaDto pessoaDto)
    {
        try
        {
            var pessoa = new Pessoa(pessoaDto.Nome, pessoaDto.Cpf, pessoaDto.DataNascimento.ToString("yyyy"));
            PessoasDaClasse.Add(pessoaDto);
            return Ok(PessoasDaClasse);
        }
        catch (ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetPessoa")]
    public IActionResult GetPessoa()
    {
        return Ok(PessoasDaClasse);
    }

    [HttpDelete("DeletePessoa")]
    public IActionResult DeletePessoa()
    {
        var index = PessoasDaClasse.Count();
        if (index != 0)
        {
            PessoasDaClasse.RemoveAt(index - 1);
            return Ok(PessoasDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}