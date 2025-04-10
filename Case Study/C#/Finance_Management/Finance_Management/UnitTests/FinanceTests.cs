using Finance_Management.Dao;
using Finance_Management.Exceptions;
using Finance_Management.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Finance_Management.UnitTests
{
    [TestFixture]
    public class FinanceSystemTests
    {
        private IFinanceRepository repository;
        private int testUserId = 20;
        private int testExpenseId;

        [SetUp]
        public void Setup()
        {
            repository = new FinanceRepositoryImpl();

            // Create a test user
            User testUser = new User(0,"testuser", "password", "test@example.com");
            //testUser.UserId = 20;
            repository.CreateUser(testUser);


            // Create a test expense
            Expense testExpense = new Expense(0,testUserId, 100.00m, 1, DateTime.Now, "Test expense");
            repository.CreateExpense(testExpense);

        }

        [Test]
        public void CreateUser_Success()
        {
            var newUser = new User(0,"newuser", "password", "new@example.com");
            bool result = repository.CreateUser(newUser);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateExpense_Success()
        {
            var newExpense = new Expense(111, testUserId, 50, 2, DateTime.Now, "Another expense");
            var result = repository.CreateExpense(newExpense);
            Assert.That(result, Is.True);
        }


        [Test]
        public void UpdateExpense_Success()
        {
            var updatedExpense = new Expense(testExpenseId, testUserId, 150, 3, DateTime.Now, "Updated expense");
            var result = repository.UpdateExpense(testUserId, updatedExpense);
            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteExpense_InvalidId_ThrowsException()
        {
            Assert.Throws<ExpenseNotFoundException>(() => repository.DeleteExpense(99999));
        }

        [Test]
        public void DeleteUser_InvalidId_ThrowsException()
        {
            Assert.Throws<UserNotFoundException>(() => repository.DeleteUser(99999));
        }

        [Test]
        public void UpdateExpense_InvalidId_ThrowsException()
        {
            var invalidExpense = new Expense(99999, testUserId, 150.00m, 3, DateTime.Now, "Invalid expense");
            Assert.Throws<ExpenseNotFoundException>(() => repository.UpdateExpense(testUserId, invalidExpense));
        }

        [TearDown]
        public void Cleanup()
        {
            try { repository.DeleteExpense(testExpenseId); } catch { }
            try { repository.DeleteUser(testUserId); } catch { }
        }
    }
}