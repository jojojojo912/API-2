using MeuProjeto.Models;

namespace MeuProjeto.Services;

public interface ITeacherService
{
    Task<Teacher> InserirAsync(Teacher teacher);
    Task<Teacher?> AtualizarAsync(int id, Teacher teacher);
    Task<IEnumerable<Teacher>> ListarTodosAsync();
    Task<Teacher?> BuscarPorIdAsync(int id);
    Task<bool> RemoverAsync(int id);
}

using MeuProjeto.Models;
using MeuProjeto.Repositories;

namespace MeuProjeto.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public Task<Teacher> InserirAsync(Teacher teacher)
    {
        teacher.Id = 0; // garante que será um novo registro
        return _repository.InserirAsync(teacher);
    }

    public Task<Teacher?> AtualizarAsync(int id, Teacher teacher)
    {
        teacher.Id = id;
        return _repository.AtualizarAsync(teacher);
    }

    public Task<IEnumerable<Teacher>> ListarTodosAsync() => _repository.ListarTodosAsync();

    public Task<Teacher?> BuscarPorIdAsync(int id) => _repository.BuscarPorIdAsync(id);

    public Task<bool> RemoverAsync(int id) => _repository.RemoverAsync(id);
}