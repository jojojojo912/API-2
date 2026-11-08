namespace MeuProjeto.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UrlLattes { get; set; } = string.Empty;
    public DateTime DataAdmissao { get; set; }
}

public DbSet<Teacher> Teachers { get; set; }

dotnet ef migrations add AddTeacher
dotnet ef database update