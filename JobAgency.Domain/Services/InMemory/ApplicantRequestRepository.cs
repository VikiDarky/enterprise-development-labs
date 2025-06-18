using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services.InMemory;

/// <summary>
/// InMemory-репозиторий для работы с заявками соискателей.
/// </summary>
public class ApplicantRequestRepository : IApplicantRequestRepository
{
    private readonly List<ApplicantRequest> _requests = new();

    public void Add(ApplicantRequest request) => _requests.Add(request);
    public ApplicantRequest GetById(int id) => _requests.FirstOrDefault(r => r.Id == id);
    public IEnumerable<ApplicantRequest> GetAll() => _requests;
    public void Update(ApplicantRequest request)
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