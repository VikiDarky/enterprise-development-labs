using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services;

/// <summary>
/// Сервис для генерации отчетов (запросы 1-6 из задания).
/// </summary>
public class ReportService
{
    private readonly IApplicantRepository _applicantRepo;
    private readonly IEmployerRepository _employerRepo;
    private readonly IJobPositionRepository _jobPositionRepo;
    private readonly IApplicantRequestRepository _applicantRequestRepo;
    private readonly IEmployerRequestRepository _employerRequestRepo;

    public ReportService(
        IApplicantRepository applicantRepo,
        IEmployerRepository employerRepo,
        IJobPositionRepository jobPositionRepo,
        IApplicantRequestRepository applicantRequestRepo,
        IEmployerRequestRepository employerRequestRepo)
    {
        _applicantRepo = applicantRepo;
        _employerRepo = employerRepo;
        _jobPositionRepo = jobPositionRepo;
        _applicantRequestRepo = applicantRequestRepo;
        _employerRequestRepo = employerRequestRepo;
    }

    // 1. Соискатели по заданной должности (упорядочены по ФИО)
    public IEnumerable<Applicant> GetApplicantsByPosition(string positionTitle)
    {
        var position = _jobPositionRepo.GetAll().FirstOrDefault(p => p.Title == positionTitle);
        if (position == null) return Enumerable.Empty<Applicant>();

        var applicantIds = _applicantRequestRepo.GetAll()
            .Where(r => r.JobPositionId == position.Id)
            .Select(r => r.ApplicantId);

        return _applicantRepo.GetAll()
            .Where(a => applicantIds.Contains(a.Id))
            .OrderBy(a => a.FullName);
    }

    // 2. Соискатели, подавшие заявки за период
    public IEnumerable<Applicant> GetApplicantsByDateRange(DateTime start, DateTime end)
    {
        var applicantIds = _applicantRequestRepo.GetAll()
            .Where(r => r.ApplicationDate >= start && r.ApplicationDate <= end)
            .Select(r => r.ApplicantId);

        return _applicantRepo.GetAll()
            .Where(a => applicantIds.Contains(a.Id));
    }

    // 3. Соискатели, подходящие под заявку работодателя
    public IEnumerable<Applicant> GetApplicantsMatchingEmployerRequest(int employerRequestId)
    {
        var request = _employerRequestRepo.GetById(employerRequestId);
        if (request == null) return Enumerable.Empty<Applicant>();

        return _applicantRepo.GetAll()
            .Where(a => a.WorkExperienceYears >= 3 && a.DesiredSalary <= request.OfferedSalary);
    }

    // 4. Количество заявок по разделам и должностям
    public Dictionary<string, int> GetRequestsCountByCategoryAndPosition()
    {
        return _jobPositionRepo.GetAll()
            .ToDictionary(
                p => $"{p.Category} - {p.Title}",
                p => _applicantRequestRepo.GetAll().Count(r => r.JobPositionId == p.Id) +
                     _employerRequestRepo.GetAll().Count(r => r.JobPositionId == p.Id));
    }

    // 5. Топ-5 работодателей по количеству заявок
    public IEnumerable<Employer> GetTop5EmployersByRequests()
    {
        return _employerRepo.GetAll()
            .OrderByDescending(e => _employerRequestRepo.GetAll().Count(r => r.EmployerId == e.Id))
            .Take(5);
    }

    // 6. Работодатели с максимальной зарплатой в заявках
    public IEnumerable<Employer> GetEmployersWithMaxSalaryOffers()
    {
        var maxSalary = _employerRequestRepo.GetAll().Max(r => r.OfferedSalary);
        var employerIds = _employerRequestRepo.GetAll()
            .Where(r => r.OfferedSalary == maxSalary)
            .Select(r => r.EmployerId);

        return _employerRepo.GetAll()
            .Where(e => employerIds.Contains(e.Id));
    }
}