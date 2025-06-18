using JobAgency.Domain.Services.InMemory;
using Xunit;

namespace JobAgency.Domain.Tests.Repositories
{
    public class ApplicantRepositoryTests
    {
        private readonly ApplicantRepository _repository;

        public ApplicantRepositoryTests()
        {
            _repository = new ApplicantRepository();
        }

        [Fact]
        public void Add_ShouldAddApplicant()
        {
            // Arrange
            var applicant = new Applicant { Id = 1, FullName = "Test Applicant" };

            // Act
            _repository.Add(applicant);

            // Assert
            var result = _repository.GetById(1);
            Assert.NotNull(result);
            Assert.Equal("Test Applicant", result.FullName);
        }

        [Fact]
        public void GetById_ShouldReturnNullForNonExistentId()
        {
            // Act
            var result = _repository.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_ShouldModifyExistingApplicant()
        {
            // Arrange
            var applicant = new Applicant { Id = 1, FullName = "Original Name" };
            _repository.Add(applicant);

            var updatedApplicant = new Applicant { Id = 1, FullName = "Updated Name" };

            // Act
            _repository.Update(updatedApplicant);

            // Assert
            var result = _repository.GetById(1);
            Assert.Equal("Updated Name", result.FullName);
        }

        [Fact]
        public void Delete_ShouldRemoveApplicant()
        {
            // Arrange
            var applicant = new Applicant { Id = 1, FullName = "To Delete" };
            _repository.Add(applicant);

            // Act
            _repository.Delete(1);

            // Assert
            var result = _repository.GetById(1);
            Assert.Null(result);
        }
    }
}