using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services.InMemory;

/// <summary>
/// InMemory-репозиторий для работы с должностями.
/// </summary>
public class JobPositionRepository : IJobPositionRepository
{
    private readonly List<JobPosition> _positions = new();

    public void Add(JobPosition position) => _positions.Add(position);
    public JobPosition GetById(int id) => _positions.FirstOrDefault(p => p.Id == id);
    public IEnumerable<JobPosition> GetAll() => _positions;
    public void Update(JobPosition position)
    {
        var existing = _positions.FirstOrDefault(p => p.Id == position.Id);
        if (existing != null)
        {
            _positions.Remove(existing);
            _positions.Add(position);
        }
    }
    public void Delete(int id) => _positions.RemoveAll(p => p.Id == id);
}