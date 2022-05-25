using Microsoft.AspNetCore.Mvc;
using ProjetoConcessionaria.Lib.Models;
using ProjetoConcessionaria.Lib.Exceptions;
using ProjetoConcessionaria.API.DTOs;

namespace ProjetoConcessionaria.API.Controllers;

[ApiController]
[Route("[controller]")]

public class ClienteController : ControllerBase
{
    public static List<ClienteDto> ClientesDaClasse { get; set; } = new List<ClienteDto>();

    public ILogger<ClienteController> Log { get; set; }

    public ClienteController(ILogger<ClienteController> log)
    {
        Log = log;
    }

    [HttpPost("SetCliente")]
    public IActionResult SetCliente(ClienteDto clienteDto)
    {
        try
        {
            var cliente = new Cliente(clienteDto.Nome, clienteDto.Cpf, clienteDto.DataNascimento.ToString("yyyy"), clienteDto.Email, clienteDto.Telefone);
            ClientesDaClasse.Add(clienteDto);
            return Ok(ClientesDaClasse);
        }
        catch (ErroDeValidacaoException ex)
        {
            Log.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCliente")]
    public IActionResult GetCliente()
    {
        return Ok(ClientesDaClasse);
    }

    [HttpDelete("DeleteCliente")]
    public IActionResult DeleteCliente()
    {
        var index = ClientesDaClasse.Count();
        if (index != 0)
        {
            ClientesDaClasse.RemoveAt(index - 1);
            return Ok(ClientesDaClasse);
        }
        return BadRequest("Essa lista está vazia");
    }
}