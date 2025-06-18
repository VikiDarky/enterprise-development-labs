namespace JobAgency.Domain.Services.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с заявками работодателей.
/// </summary>
public interface IEmployerRequestRepository
{
    void Add(EmployerRequest request);
    EmployerRequest GetById(int id);
    IEnumerable<EmployerRequest> GetAll();
    void Update(EmployerRequest request);
    void Delete(int id);
}