using MeuProjeto.Models;
using MeuProjeto.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    // GET api/teacher
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> ListarTodos()
    {
        return Ok(await _service.ListarTodosAsync());
    }

    // GET api/teacher/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Teacher>> BuscarPorId(int id)
    {
        var teacher = await _service.BuscarPorIdAsync(id);
        return teacher is null ? NotFound() : Ok(teacher);
    }

    // POST api/teacher
    [HttpPost]
    public async Task<ActionResult<Teacher>> Inserir([FromBody] Teacher teacher)
    {
        var criado = await _service.InserirAsync(teacher);
        return CreatedAtAction(nameof(BuscarPorId), new { id = criado.Id }, criado);
    }

    // PUT api/teacher/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Teacher>> Atualizar(int id, [FromBody] Teacher teacher)
    {
        var atualizado = await _service.AtualizarAsync(id, teacher);
        return atualizado is null ? NotFound() : Ok(atualizado);
    }

    // DELETE api/teacher/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var removido = await _service.RemoverAsync(id);
        return removido ? NoContent() : NotFound();
    }
}