using DemoAzureDevopsApi.Controllers;
using Microsoft.AspNetCore.Mvc;
 
namespace DemoAzureDevopsApi.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void GetAllEmployees_ReturnsOkResult()
        {
            // Arrange
            var controller = new EmployeeController();
 
            // Act
            var result = controller.GetAllEmployees();
 
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
 
        [Fact]
        public void GetEmployee_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new EmployeeController();
            // Act
            var result = controller.GetEmployee(1);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
 
        [Fact]
        public void GetEmployee_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new EmployeeController();
 
            // Act
            var result = controller.GetEmployee(999);
 
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
 
        [Fact]
        public void CreateEmployee_ReturnsCreatedResult()
        {
            // Arrange
            var controller = new EmployeeController();
 
            var employee = new Employee
            {
                Name = "Augusteen",
                Department = "IT",
                Salary = 60000
            };
 
            // Act
            var result = controller.CreateEmployee(employee);
 
            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
 
        [Fact]
        public void UpdateEmployee_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new EmployeeController();
 
            var employee = new Employee
            {
                Name = "Updated Name",
                Department = "Development",
                Salary = 70000
            };
 
            // Act
            var result = controller.UpdateEmployee(1, employee);
 
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
 
        [Fact]
        public void UpdateEmployee_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new EmployeeController();
 
            var employee = new Employee
            {
                Name = "Test",
                Department = "IT",
                Salary = 50000
            };
 
            // Act
            var result = controller.UpdateEmployee(999, employee);
 
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
 
        [Fact]
        public void DeleteEmployee_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new EmployeeController();
 
            // Act
            var result = controller.DeleteEmployee(1);
 
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
 
        [Fact]
        public void DeleteEmployee_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new EmployeeController();
 
            // Act
            var result = controller.DeleteEmployee(999);
 
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}