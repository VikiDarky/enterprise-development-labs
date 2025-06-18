namespace JobAgency.Domain.Services.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с работодателями.
/// </summary>
public interface IEmployerRepository
{
    void Add(Employer employer);
    Employer GetById(int id);
    IEnumerable<Employer> GetAll();
    void Update(Employer employer);
    void Delete(int id);
}