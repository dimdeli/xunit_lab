using Xunit;
using Domain;

namespace WebApp.Tests
{
    public class Person_UnitTests
    {
        public Person_UnitTests()
        {
            //initialize
        }

        [Fact]
        public void GetFullName_Succeed()
        {
            // Arrange
            const string expectedFullName = "foo bar";
            var p = new Person();

            // Act
            p.FirstName = "foo";
            p.LastName = "bar";

            // Assert
            Assert.Equal(expectedFullName, p.GetFullName());
        }

        [Fact]
        public void GetFullName_NullFirstName_Succeed()
        {
            // Arrange
            const string expectedFullName = " bar";
            var p = new Person();

            // Act
            p.FirstName = null;
            p.LastName = "bar";

            // Assert
            Assert.Equal(expectedFullName, p.GetFullName());
        }
    }
}
