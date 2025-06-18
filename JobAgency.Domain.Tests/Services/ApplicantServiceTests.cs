using JobAgency.Domain.Services;
using JobAgency.Domain.Services.InMemory;
using Xunit;

namespace JobAgency.Domain.Tests.Services
{
    public class ApplicantServiceTests
    {
        private readonly ApplicantService _service;
        private readonly ApplicantRepository _repository;

        public ApplicantServiceTests()
        {
            _repository = new ApplicantRepository();
            _service = new ApplicantService(_repository);
        }

        [Fact]
        public void AddApplicant_ShouldAddToRepository()
        {
            // Arrange
            var applicant = new Applicant { Id = 1, FullName = "Test Applicant" };

            // Act
            _service.AddApplicant(applicant);

            // Assert
            var result = _repository.GetById(1);
            Assert.NotNull(result);
            Assert.Equal("Test Applicant", result.FullName);
        }

        [Fact]
        public void GetAllApplicants_ShouldReturnAllAdded()
        {
            // Arrange
            _service.AddApplicant(new Applicant { Id = 1, FullName = "First" });
            _service.AddApplicant(new Applicant { Id = 2, FullName = "Second" });

            // Act
            var result = _service.GetAllApplicants();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void UpdateApplicant_ShouldModifyExisting()
        {
            // Arrange
            _service.AddApplicant(new Applicant { Id = 1, FullName = "Original" });
            var updated = new Applicant { Id = 1, FullName = "Updated" };

            // Act
            _service.UpdateApplicant(updated);

            // Assert
            var result = _service.GetApplicant(1);
            Assert.Equal("Updated", result.FullName);
        }
    }
}