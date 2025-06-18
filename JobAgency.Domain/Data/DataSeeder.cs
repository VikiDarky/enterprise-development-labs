using JobAgency.Domain.Services.InMemory;
using JobAgency.Domain.Services.Interfaces;

namespace JobAgency.Domain.Data;

/// <summary>
/// Заполняет InMemory-хранилища тестовыми данными.
/// </summary>
public static class DataSeeder
{
    public static void Seed(
        IApplicantRepository applicantRepo,
        IEmployerRepository employerRepo,
        IJobPositionRepository jobPositionRepo,
        IApplicantRequestRepository applicantRequestRepo,
        IEmployerRequestRepository employerRequestRepo)
    {
        // Добавляем должности
        var itCategory = new JobPosition { Id = 1, Category = JobCategory.IT, Title = "Программист" };
        var financeCategory = new JobPosition { Id = 2, Category = JobCategory.Finance, Title = "Аналитик" };
        var marketingCategory = new JobPosition { Id = 3, Category = JobCategory.Marketing, Title = "Маркетолог" };

        jobPositionRepo.Add(itCategory);
        jobPositionRepo.Add(financeCategory);
        jobPositionRepo.Add(marketingCategory);

        // Добавляем соискателей
        var applicant1 = new Applicant { Id = 1, FullName = "Иванов Иван", Phone = "+79991234567", WorkExperienceYears = 3, Education = "Высшее", DesiredSalary = 100000 };
        var applicant2 = new Applicant { Id = 2, FullName = "Петров Петр", Phone = "+79997654321", WorkExperienceYears = 1, Education = "Среднее", DesiredSalary = 60000 };

        applicantRepo.Add(applicant1);
        applicantRepo.Add(applicant2);

        // Добавляем работодателей
        var employer1 = new Employer { Id = 1, CompanyName = "TechCorp", ContactPerson = "Алексей", Phone = "+78005553535" };
        var employer2 = new Employer { Id = 2, CompanyName = "FinanceGroup", ContactPerson = "Мария", Phone = "+78005005050" };

        employerRepo.Add(employer1);
        employerRepo.Add(employer2);

        // Добавляем заявки соискателей
        var applicantRequest1 = new ApplicantRequest { Id = 1, ApplicantId = 1, JobPositionId = 1, ApplicationDate = DateTime.Now.AddDays(-5) };
        var applicantRequest2 = new ApplicantRequest { Id = 2, ApplicantId = 2, JobPositionId = 2, ApplicationDate = DateTime.Now.AddDays(-2) };

        applicantRequestRepo.Add(applicantRequest1);
        applicantRequestRepo.Add(applicantRequest2);

        // Добавляем заявки работодателей
        var employerRequest1 = new EmployerRequest { Id = 1, EmployerId = 1, JobPositionId = 1, Requirements = "Опыт работы от 3 лет", OfferedSalary = 120000, ApplicationDate = DateTime.Now.AddDays(-3) };
        var employerRequest2 = new EmployerRequest { Id = 2, EmployerId = 2, JobPositionId = 2, Requirements = "Знание Excel", OfferedSalary = 80000, ApplicationDate = DateTime.Now.AddDays(-1) };

        employerRequestRepo.Add(employerRequest1);
        employerRequestRepo.Add(employerRequest2);
    }
}