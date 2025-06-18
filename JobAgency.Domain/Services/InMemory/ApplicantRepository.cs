using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services.InMemory;

/// <summary>
/// InMemory-репозиторий для работы с соискателями.
/// </summary>
public class ApplicantRepository : IApplicantRepository
{
    private readonly List<Applicant> _applicants = new();

    public void Add(Applicant applicant) => _applicants.Add(applicant);
    public Applicant GetById(int id) => _applicants.FirstOrDefault(a => a.Id == id);
    public IEnumerable<Applicant> GetAll() => _applicants;
    public void Update(Applicant applicant)
    {
        var existing = _applicants.FirstOrDefault(a => a.Id == applicant.Id);
        if (existing != null)
        {
            _applicants.Remove(existing);
            _applicants.Add(applicant);
        }
    }
    public void Delete(int id) => _applicants.RemoveAll(a => a.Id == id);
}