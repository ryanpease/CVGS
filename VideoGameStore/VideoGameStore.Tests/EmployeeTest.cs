/* Filename: EmployeeTest.cs
 * Description: This class is responsible for unit testing for the Employee class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created Constructor and Field Tests
 *      Ryan Pease 2016-10-28: Created Validation Tests
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 
*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;
using RPClassLibrary;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void EmployeeTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Employee employee = new Employee();

            // Assert
            Assert.IsNotNull(employee);
        }

        [Test]
        // This test is responsible for checking the employee_id field
        public void EmployeeTest_EmployeeIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            int expected = 90;
            int actual;

            // Act
            employee.employee_id = expected;

            // Assert
            actual = employee.employee_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the employee_password field
        public void EmployeeTest_PasswordWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "1234";
            string actual;

            // Act
            employee.employee_password = expected;

            // Assert
            actual = employee.employee_password;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the login_failures field
        public void EmployeeTest_LoginFailuresWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            int expected = 4;
            int actual;

            // Act
            employee.login_failures = expected;

            // Assert
            actual = employee.login_failures;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the first_name field
        public void EmployeeTest_FirstNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "Winston";
            string actual;

            // Act
            employee.first_name = expected;

            // Assert
            actual = employee.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the last_name field
        public void EmployeeTest_LastNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "Ping";
            string actual;

            // Act
            employee.last_name = expected;

            // Assert
            actual = employee.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the phone field
        public void EmployeeTest_PhoneNumberWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "(519) 111-1212";
            string actual;

            // Act
            employee.phone = expected;

            // Assert
            actual = employee.phone;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the email field
        public void EmployeeTest_EmailWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "greg_shalay@outlook.com";
            string actual;

            // Act
            employee.email = expected;

            // Assert
            actual = employee.email;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the gender field
        public void EmployeeTest_GenderWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "Female";
            string actual;

            // Act
            employee.gender = expected;

            // Assert
            actual = employee.gender;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the birthdate field
        public void EmployeeTest_BirthDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            DateTime expected = new DateTime(2015, 1, 12);
            DateTime actual = new DateTime();

            // Act
            employee.birthdate = expected;

            // Assert
            actual = employee.birthdate;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_hired field
        public void EmployeeTest_DateHiredWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            DateTime expected = new DateTime(1978, 10, 28);
            DateTime actual = new DateTime();

            // Act
            employee.birthdate = expected;

            // Assert
            actual = employee.birthdate;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_admin field
        public void EmployeeTest_IsAdminWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            bool expected = false;
            bool actual;

            // Act
            employee.is_admin = expected;

            // Assert
            actual = employee.is_admin;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_inactive field
        public void EmployeeTest_IsInactiveWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            bool expected = true;
            bool actual;

            // Act
            employee.is_inactive = expected;

            // Assert
            actual = employee.is_inactive;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_locked_out field
        public void EmployeeTest_IsLockedOutWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            bool expected = true;
            bool actual;

            // Act
            employee.is_locked_out = expected;

            // Assert
            actual = employee.is_locked_out;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the notes field
        public void EmployeeTest_NotesWithCorrectType_ShouldPass()
        {
            // Arrange
            Employee employee = new Employee();
            string expected = "This note is a very short one.";
            string actual;

            // Act
            employee.notes = expected;
            
            // Assert
            actual = employee.notes;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the First Name validation (value in lowercase characters)
        public void EmployeeTest_Validation_FirstNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            Employee employee = new Employee();
            string firstName = RPValidations.Capitalize("roger", false);
            string expected = "Roger";

            // Act
            employee.first_name = firstName;

            // Assert
            string actual = employee.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Last Name validation (value in lowercase characters)
        public void EmployeeTest_Validation_LastNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            Employee employee = new Employee();
            string lastName = RPValidations.Capitalize("wilco", false);
            string expected = "Wilco";

            // Act
            employee.last_name = lastName;

            // Assert
            string actual = employee.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Phone Number validation (value including dash delimiters)
        public void EmployeeTest_Validation_PhoneNumberWithDashes_ShouldRemoveDashes()
        {
            // Arrange
            Employee employee = new Employee();
            string phone = RPValidations.FormatPhoneNumber("000-000-0000");
            string expected = "0000000000";

            // Act
            employee.phone = phone;

            // Assert
            string actual = employee.phone;
            Assert.AreEqual(expected, actual);
        }
    }
}
