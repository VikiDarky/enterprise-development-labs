using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services;

/// <summary>
/// Сервис для работы с соискателями.
/// </summary>
public class ApplicantService
{
    private readonly IApplicantRepository _repository;

    public ApplicantService(IApplicantRepository repository)
    {
        _repository = repository;
    }

    public void AddApplicant(Applicant applicant) => _repository.Add(applicant);
    public Applicant GetApplicant(int id) => _repository.GetById(id);
    public IEnumerable<Applicant> GetAllApplicants() => _repository.GetAll();
    public void UpdateApplicant(Applicant applicant) => _repository.Update(applicant);
    public void DeleteApplicant(int id) => _repository.Delete(id);
}