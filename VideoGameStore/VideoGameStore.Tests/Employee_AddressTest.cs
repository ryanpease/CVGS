/* Filename: Employee_AddressTest.cs
 * Description: This class is responsible for unit testing for the Employee_Address class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests. 
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 
*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class Employee_AddressTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Employee_AddressTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Employee_Address empAddress = new Employee_Address();

            // Assert
            Assert.IsNotNull(empAddress);
        }

        [Test]
        // This test is responsible for checking the employee_id field
        public void Employee_AddressTest_EmployeeIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee_Address empAddress = new Employee_Address();
            int expected = 34;
            int actual;

            // Act
            empAddress.employee_id = expected;

            // Assert
            actual = empAddress.employee_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void Employee_AddressTest_AddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee_Address empAddress = new Employee_Address();
            int expected = 34;
            int actual;

            // Act
            empAddress.address_id = expected;

            // Assert
            actual = empAddress.address_id;            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_name field
        public void Employee_AddressTest_AddressNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee_Address empAddress = new Employee_Address();
            string expected = "765 Fake Avenue";
            string actual;

            // Act
            empAddress.address_name = expected;

            // Assert
            actual = empAddress.address_name;
            Assert.AreEqual(expected, actual);
        }
    }
}
