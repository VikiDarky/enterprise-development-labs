using JobAgency.Domain.Services;
using JobAgency.Domain.Services.InMemory;
using Xunit;

namespace JobAgency.Domain.Tests.Services
{
    public class ReportServiceTests
    {
        private readonly ReportService _service;
        private readonly ApplicantRepository _applicantRepo;
        private readonly EmployerRepository _employerRepo;
        private readonly JobPositionRepository _jobPositionRepo;
        private readonly ApplicantRequestRepository _applicantRequestRepo;
        private readonly EmployerRequestRepository _employerRequestRepo;

        public ReportServiceTests()
        {
            _applicantRepo = new ApplicantRepository();
            _employerRepo = new EmployerRepository();
            _jobPositionRepo = new JobPositionRepository();
            _applicantRequestRepo = new ApplicantRequestRepository();
            _employerRequestRepo = new EmployerRequestRepository();

            _service = new ReportService(
                _applicantRepo,
                _employerRepo,
                _jobPositionRepo,
                _applicantRequestRepo,
                _employerRequestRepo);

            SeedTestData();
        }

        private void SeedTestData()
        {
            // Добавляем должности
            var programmer = new JobPosition { Id = 1, Category = JobCategory.IT, Title = "Программист" };
            var analyst = new JobPosition { Id = 2, Category = JobCategory.Finance, Title = "Аналитик" };
            _jobPositionRepo.Add(programmer);
            _jobPositionRepo.Add(analyst);

            // Добавляем соискателей
            var applicant1 = new Applicant { Id = 1, FullName = "Иванов Иван", WorkExperienceYears = 3, DesiredSalary = 100000 };
            var applicant2 = new Applicant { Id = 2, FullName = "Петров Петр", WorkExperienceYears = 1, DesiredSalary = 60000 };
            _applicantRepo.Add(applicant1);
            _applicantRepo.Add(applicant2);

            // Добавляем работодателей
            var employer1 = new Employer { Id = 1, CompanyName = "TechCorp" };
            var employer2 = new Employer { Id = 2, CompanyName = "FinanceGroup" };
            _employerRepo.Add(employer1);
            _employerRepo.Add(employer2);

            // Добавляем заявки соискателей
            var appRequest1 = new ApplicantRequest { Id = 1, ApplicantId = 1, JobPositionId = 1, ApplicationDate = DateTime.Now.AddDays(-5) };
            var appRequest2 = new ApplicantRequest { Id = 2, ApplicantId = 2, JobPositionId = 2, ApplicationDate = DateTime.Now.AddDays(-2) };
            _applicantRequestRepo.Add(appRequest1);
            _applicantRequestRepo.Add(appRequest2);

            // Добавляем заявки работодателей
            var empRequest1 = new EmployerRequest { Id = 1, EmployerId = 1, JobPositionId = 1, OfferedSalary = 120000, ApplicationDate = DateTime.Now.AddDays(-3) };
            var empRequest2 = new EmployerRequest { Id = 2, EmployerId = 2, JobPositionId = 2, OfferedSalary = 80000, ApplicationDate = DateTime.Now.AddDays(-1) };
            var empRequest3 = new EmployerRequest { Id = 3, EmployerId = 1, JobPositionId = 1, OfferedSalary = 150000, ApplicationDate = DateTime.Now };
            _employerRequestRepo.Add(empRequest1);
            _employerRequestRepo.Add(empRequest2);
            _employerRequestRepo.Add(empRequest3);
        }

        [Fact]
        public void GetApplicantsByPosition_ShouldReturnCorrectApplicants()
        {
            // Act
            var result = _service.GetApplicantsByPosition("Программист");

            // Assert
            Assert.Single(result);
            Assert.Equal("Иванов Иван", result.First().FullName);
        }

        [Fact]
        public void GetApplicantsByDateRange_ShouldFilterCorrectly()
        {
            // Arrange
            var start = DateTime.Now.AddDays(-4);
            var end = DateTime.Now.AddDays(-1);

            // Act
            var result = _service.GetApplicantsByDateRange(start, end);

            // Assert
            Assert.Single(result);
            Assert.Equal("Петров Петр", result.First().FullName);
        }

        [Fact]
        public void GetApplicantsMatchingEmployerRequest_ShouldFilterBySalaryAndExperience()
        {
            // Act
            var result = _service.GetApplicantsMatchingEmployerRequest(1); // Заявка с зарплатой 120000

            // Assert
            Assert.Single(result);
            Assert.Equal("Иванов Иван", result.First().FullName);
        }

        [Fact]
        public void GetTop5EmployersByRequests_ShouldReturnOrderedList()
        {
            // Act
            var result = _service.GetTop5EmployersByRequests();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("TechCorp", result.First().CompanyName); // У TechCorp 2 заявки
            Assert.Equal("FinanceGroup", result.Last().CompanyName); // У FinanceGroup 1 заявка
        }

        [Fact]
        public void GetEmployersWithMaxSalaryOffers_ShouldReturnCorrectEmployer()
        {
            // Act
            var result = _service.GetEmployersWithMaxSalaryOffers();

            // Assert
            Assert.Single(result);
            Assert.Equal("TechCorp", result.First().CompanyName); // Максимальная зарплата 150000 у TechCorp
        }
    }
}