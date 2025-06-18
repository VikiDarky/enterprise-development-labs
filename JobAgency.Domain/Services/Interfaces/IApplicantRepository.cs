namespace JobAgency.Domain.Services.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с соискателями.
/// </summary>
public interface IApplicantRepository
{
    void Add(Applicant applicant);
    Applicant GetById(int id);
    IEnumerable<Applicant> GetAll();
    void Update(Applicant applicant);
    void Delete(int id);
}