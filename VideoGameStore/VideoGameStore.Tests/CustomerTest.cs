/* Filename: CustomerTest.cs
 * Description: This class is responsible for unit testing for the Customer class.
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
    public class CustomerTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void CustomerTest_CustomerConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Customer customer = new Customer();

            // Assert
            Assert.IsNotNull(customer);
        }

        [Test]
        // This test is responsible for checking the customer_id field
        public void CustomerTest_CustomerIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            int expected = 1;
            int actual;

            // Act
            customer.customer_id = expected;

            // Assert
            actual = customer.customer_id;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the username field
        public void CustomerTest_UsernameWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "CaptainWonderbar";
            string actual;

            // Act
            customer.username = expected;

            // Assert
            actual = customer.username;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the email field
        public void CustomerTest_EmailWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "CaptainWunderbar@wunderbar.com";
            string actual;

            // Act
            customer.email = expected;

            // Assert
            actual = customer.email;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the customer_password field
        public void CustomerTest_PasswordWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "wunderbar23432";
            string actual;

            // Act
            customer.customer_password = expected;

            // Assert
            actual = customer.customer_password;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the login_failures field
        public void CustomerTest_LoginFailuresWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            int expected = 12;
            int actual;

            // Act
            customer.login_failures = expected;

            // Assert
            actual = customer.login_failures;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the first_name field
        public void CustomerTest_FirstNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "Gerrard";
            string actual;

            // Act
            customer.first_name = expected;

            // Assert
            actual = customer.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the last_name field
        public void CustomerTest_LastNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "Wunter";
            string actual;

            // Act
            customer.last_name = expected;

            // Assert
            actual = customer.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the phone field
        public void CustomerTest_PhoneNumberWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "(519) 555-5555";
            string actual;

            // Act
            customer.phone = expected;

            // Assert
            actual = customer.phone;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the gender field
        public void CustomerTest_GenderWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "M";
            string actual;

            // Act
            customer.gender = expected;

            // Assert
            actual = customer.gender;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the birthdate field
        public void CustomerTest_BirthDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            DateTime expected = new DateTime(2005, 3, 7);
            DateTime actual = new DateTime();

            // Act
            customer.birthdate = expected;

            // Assert
            actual = customer.birthdate;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_joined field
        public void CustomerTest_DateJoinedWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            DateTime expected = new DateTime(2010, 8, 9);
            DateTime actual = new DateTime();

            // Act
            customer.date_joined = expected;

            // Assert
            actual = customer.date_joined;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_member field
        public void CustomerTest_IsMemberWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            bool expected = true;
            bool actual;

            // Act
            customer.is_member = expected;

            // Assert
            actual = customer.is_member;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_inactive field
        public void CustomerTest_IsInactiveWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            bool expected = true;
            bool actual;

            // Act
            customer.is_inactive = expected;

            // Assert
            actual = customer.is_inactive;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_locked_out field
        public void CustomerTest_IsLockedOutWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            bool expected = true;
            bool actual;

            // Act
            customer.is_locked_out = expected;

            // Assert
            actual = customer.is_locked_out;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_on_email_list field
        public void CustomerTest_IsOnEmailListWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            bool expected = true;
            bool actual;

            // Act
            customer.is_on_email_list = expected;
            
            // Assert
            actual = customer.is_on_email_list;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the favorite_platform field
        public void CustomerTest_FavoritePlatformWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "PC";
            string actual;

            // Act
            customer.favorite_platform = expected;
            
            // Assert
            actual = customer.favorite_platform;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the favorite_category field
        public void CustomerTest_FavoriteCategoryWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "Horror";
            string actual;

            // Act
            customer.favorite_category = expected;

            // Assert
            actual = customer.favorite_category;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the notes field
        public void CustomerTest_NotesWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer customer = new Customer();
            string expected = "This is a note.";
            string actual;

            // Act
            customer.notes = expected;

            // Assert
            actual = customer.notes;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the First Name validation (value in lowercase characters)
        public void CustomerTest_Validation_FirstNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            Customer customer = new Customer();
            string firstName = RPValidations.Capitalize("leroy", false);
            string expected = "Leroy";

            // Act
            customer.first_name = firstName;

            // Assert
            string actual = customer.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Last Name validation (value in lowercase characters)
        public void CustomerTest_Validation_LastNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            Customer customer = new Customer();
            string lastName = RPValidations.Capitalize("jenkins", false);
            string expected = "Jenkins";

            // Act
            customer.last_name = lastName;

            // Assert
            string actual = customer.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Phone Number validation (value including dash delimiters)
        public void CustomerTest_Validation_PhoneNumberWithDashes_ShouldRemoveDashes()
        {
            // Arrange
            Customer customer = new Customer();
            string phone = RPValidations.FormatPhoneNumber("000-000-0000");
            string expected = "0000000000";

            // Act
            customer.phone = phone;

            // Assert
            string actual = customer.phone;
            Assert.AreEqual(expected, actual);
        }            
    }
}
