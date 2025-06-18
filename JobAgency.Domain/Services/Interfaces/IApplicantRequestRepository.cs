namespace JobAgency.Domain.Services.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с заявками соискателей.
/// </summary>
public interface IApplicantRequestRepository
{
    void Add(ApplicantRequest request);
    ApplicantRequest GetById(int id);
    IEnumerable<ApplicantRequest> GetAll();
    void Update(ApplicantRequest request);
    void Delete(int id);
}