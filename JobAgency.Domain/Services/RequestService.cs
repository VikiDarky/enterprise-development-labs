using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Services;

/// <summary>
/// Сервис для обработки заявок (соискателей и работодателей).
/// </summary>
public class RequestService
{
    private readonly IApplicantRequestRepository _applicantRequestRepo;
    private readonly IEmployerRequestRepository _employerRequestRepo;

    public RequestService(
        IApplicantRequestRepository applicantRequestRepo,
        IEmployerRequestRepository employerRequestRepo)
    {
        _applicantRequestRepo = applicantRequestRepo;
        _employerRequestRepo = employerRequestRepo;
    }

    public void AddApplicantRequest(ApplicantRequest request) => _applicantRequestRepo.Add(request);
    public void AddEmployerRequest(EmployerRequest request) => _employerRequestRepo.Add(request);
    public IEnumerable<ApplicantRequest> GetApplicantRequests() => _applicantRequestRepo.GetAll();
    public IEnumerable<EmployerRequest> GetEmployerRequests() => _employerRequestRepo.GetAll();
}