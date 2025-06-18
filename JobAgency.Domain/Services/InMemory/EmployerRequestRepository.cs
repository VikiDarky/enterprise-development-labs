using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services.InMemory;

/// <summary>
/// InMemory-репозиторий для работы с заявками работодателей.
/// </summary>
public class EmployerRequestRepository : IEmployerRequestRepository
{
    private readonly List<EmployerRequest> _requests = new();

    public void Add(EmployerRequest request) => _requests.Add(request);
    public EmployerRequest GetById(int id) => _requests.FirstOrDefault(r => r.Id == id);
    public IEnumerable<EmployerRequest> GetAll() => _requests;
    public void Update(EmployerRequest request)
    {
        var existing = _requests.FirstOrDefault(r => r.Id == request.Id);
        if (existing != null)
        {
            _requests.Remove(existing);
            _requests.Add(request);
        }
    }
    public void Delete(int id) => _requests.RemoveAll(r => r.Id == id);
}