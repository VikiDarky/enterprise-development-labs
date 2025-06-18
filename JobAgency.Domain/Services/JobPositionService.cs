using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services;

/// <summary>
/// Сервис для работы с должностями.
/// </summary>
public class JobPositionService
{
    private readonly IJobPositionRepository _repository;

    public JobPositionService(IJobPositionRepository repository)
    {
        _repository = repository;
    }

    public void AddPosition(JobPosition position) => _repository.Add(position);
    public JobPosition GetPosition(int id) => _repository.GetById(id);
    public IEnumerable<JobPosition> GetAllPositions() => _repository.GetAll();
    public void UpdatePosition(JobPosition position) => _repository.Update(position);
    public void DeletePosition(int id) => _repository.Delete(id);
}