namespace JobAgency.Domain.Services.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с должностями.
/// </summary>
public interface IJobPositionRepository
{
    void Add(JobPosition position);
    JobPosition GetById(int id);
    IEnumerable<JobPosition> GetAll();
    void Update(JobPosition position);
    void Delete(int id);
}