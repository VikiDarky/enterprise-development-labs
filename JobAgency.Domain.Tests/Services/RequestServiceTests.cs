using JobAgency.Domain.Services;
using JobAgency.Domain.Services.InMemory;
using Xunit;

namespace JobAgency.Domain.Tests.Services
{
    public class RequestServiceTests
    {
        private readonly RequestService _service;
        private readonly ApplicantRequestRepository _applicantRequestRepo;
        private readonly EmployerRequestRepository _employerRequestRepo;

        public RequestServiceTests()
        {
            _applicantRequestRepo = new ApplicantRequestRepository();
            _employerRequestRepo = new EmployerRequestRepository();
            _service = new RequestService(_applicantRequestRepo, _employerRequestRepo);
        }

        [Fact]
        public void AddApplicantRequest_ShouldAddToRepository()
        {
            // Arrange
            var request = new ApplicantRequest { Id = 1, ApplicantId = 1, JobPositionId = 1 };

            // Act
            _service.AddApplicantRequest(request);

            // Assert
            var result = _applicantRequestRepo.GetById(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.ApplicantId);
        }

        [Fact]
        public void AddEmployerRequest_ShouldAddToRepository()
        {
            // Arrange
            var request = new EmployerRequest { Id = 1, EmployerId = 1, JobPositionId = 1 };

            // Act
            _service.AddEmployerRequest(request);

            // Assert
            var result = _employerRequestRepo.GetById(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.EmployerId);
        }

        [Fact]
        public void GetApplicantRequests_ShouldReturnAllAdded()
        {
            // Arrange
            _service.AddApplicantRequest(new ApplicantRequest { Id = 1 });
            _service.AddApplicantRequest(new ApplicantRequest { Id = 2 });

            // Act
            var result = _service.GetApplicantRequests();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetEmployerRequests_ShouldReturnAllAdded()
        {
            // Arrange
            _service.AddEmployerRequest(new EmployerRequest { Id = 1 });
            _service.AddEmployerRequest(new EmployerRequest { Id = 2 });

            // Act
            var result = _service.GetEmployerRequests();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}