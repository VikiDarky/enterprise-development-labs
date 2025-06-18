using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services.InMemory;

/// <summary>
/// InMemory-репозиторий для работы с работодателями.
/// </summary>
public class EmployerRepository : IEmployerRepository
{
    private readonly List<Employer> _employers = new();

    public void Add(Employer employer) => _employers.Add(employer);
    public Employer GetById(int id) => _employers.FirstOrDefault(e => e.Id == id);
    public IEnumerable<Employer> GetAll() => _employers;
    public void Update(Employer employer)
    {
        var existing = _employers.FirstOrDefault(e => e.Id == employer.Id);
        if (existing != null)
        {
            _employers.Remove(existing);
            _employers.Add(employer);
        }
    }
    public void Delete(int id) => _employers.RemoveAll(e => e.Id == id);
}