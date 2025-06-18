using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services;

/// <summary>
/// Сервис для работы с работодателями.
/// </summary>
public class EmployerService
{
    private readonly IEmployerRepository _repository;

    public EmployerService(IEmployerRepository repository)
    {
        _repository = repository;
    }

    public void AddEmployer(Employer employer) => _repository.Add(employer);
    public Employer GetEmployer(int id) => _repository.GetById(id);
    public IEnumerable<Employer> GetAllEmployers() => _repository.GetAll();
    public void UpdateEmployer(Employer employer) => _repository.Update(employer);
    public void DeleteEmployer(int id) => _repository.Delete(id);
}