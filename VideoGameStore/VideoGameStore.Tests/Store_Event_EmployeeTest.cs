/* Filename: Store_Event_EmployeeTest.cs
 * Description: This class is responsible for unit testing for the Store_Event_Employee class.
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
    public class Store_Event_EmployeeTest
    {
        [Test]        
        // This test is responsible for checking the constructor
        public void Store_Event_EmployeeTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Store_Event_Employee sem = new Store_Event_Employee();

            // Assert
            Assert.IsNotNull(sem);
        }

        [Test]
        // This test is responsible for checking the store_event_employee_id field
        public void Store_Event_EmployeeTest_StoreEventEmployeeIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Employee sem = new Store_Event_Employee();
            int expected = 123;
            int actual;

            // Act
            sem.store_event_employee_id = expected;

            // Assert
            actual = sem.store_event_employee_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the store_event_id field
        public void Store_Event_EmployeeTest_StoreEventIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Employee sem = new Store_Event_Employee();
            int expected = 123;
            int actual;

            // Act
            sem.store_event_id = expected;

            // Assert
            actual = sem.store_event_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the employee_id field
        public void Store_Event_EmployeeTest_EmployeeIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Employee sem = new Store_Event_Employee();
            int expected = 123;
            int actual;

            // Act
            sem.employee_id = expected;

            // Assert
            actual = sem.employee_id;
            Assert.AreEqual(expected, actual);
        }
    }
}
