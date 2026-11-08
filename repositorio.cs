using MeuProjeto.Models;

namespace MeuProjeto.Repositories;

public interface ITeacherRepository
{
    Task<Teacher> InserirAsync(Teacher teacher);
    Task<Teacher?> AtualizarAsync(Teacher teacher);
    Task<IEnumerable<Teacher>> ListarTodosAsync();
    Task<Teacher?> BuscarPorIdAsync(int id);
    Task<bool> RemoverAsync(int id);
}

using MeuProjeto.Data;
using MeuProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Teacher> InserirAsync(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task<Teacher?> AtualizarAsync(Teacher teacher)
    {
        var existente = await _context.Teachers.FindAsync(teacher.Id);
        if (existente is null) return null;

        existente.Name = teacher.Name;
        existente.Email = teacher.Email;
        existente.UrlLattes = teacher.UrlLattes;
        existente.DataAdmissao = teacher.DataAdmissao;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<IEnumerable<Teacher>> ListarTodosAsync()
    {
        return await _context.Teachers.AsNoTracking().ToListAsync();
    }

    public async Task<Teacher?> BuscarPorIdAsync(int id)
    {
        return await _context.Teachers.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher is null) return false;

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return true;
    }
}