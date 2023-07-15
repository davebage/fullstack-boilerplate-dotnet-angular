using backend.Controllers;
using backend.Models;
using backend.Repository;
using BackEndTests.Providers;
using FluentAssertions;

namespace BackEndTests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        [Test]
        public void CreateAndStoreATransaction()
        {
            var testableDateTimeProvider = new TestableDateTimeProvider();
            var testableTransactionIdProvider = new TestableTransactionIdProvider();
            var expectedTransaction = new Transaction
            {
                account_id = new Guid("0afd02d3-6c59-46e7-b7bc-893c5e0b7ac2"),
                transaction_id = testableTransactionIdProvider.NewTransactionId(),
                amount = 10,
                created_at = testableDateTimeProvider.UtcNow(),
            };

            var repository = new TransactionsRepository(
                testableDateTimeProvider, 
                testableTransactionIdProvider);
            var transaction = repository.AddTransaction(expectedTransaction.account_id, expectedTransaction.amount);

            transaction.Should().BeEquivalentTo(expectedTransaction);
        }

        [Test]
        public void ReturnAllStoredTransactions()
        {
            var testableDateTimeProvider = new TestableDateTimeProvider();
            var testableTransactionIdProvider = new TestableTransactionIdProvider();
            var repository = new TransactionsRepository(
                testableDateTimeProvider,
                testableTransactionIdProvider);
            var expectedTransaction = new Transaction
            {
                account_id = new Guid("0afd02d3-6c59-46e7-b7bc-893c5e0b7ac2"),
                transaction_id = testableTransactionIdProvider.NewTransactionId(),
                amount = 10,
                created_at = testableDateTimeProvider.UtcNow(),
            };
            repository.AddTransaction(expectedTransaction.account_id, expectedTransaction.amount);
            var transactions = repository.GetAllTransactions();

            transactions.Should().HaveCount(1);
            transactions[0].Should().BeEquivalentTo(expectedTransaction);
        }

        [Test]
        public void ReturnAStoredTransactionByItsId()
        {
            var testableDateTimeProvider = new TestableDateTimeProvider();
            var testableTransactionIdProvider = new TestableTransactionIdProvider();
            var repository = new TransactionsRepository(
                testableDateTimeProvider,
                testableTransactionIdProvider);
            var expectedTransaction = new Transaction
            {
                account_id = new Guid("0afd02d3-6c59-46e7-b7bc-893c5e0b7ac2"),
                transaction_id = testableTransactionIdProvider.NewTransactionId(),
                amount = 10,
                created_at = testableDateTimeProvider.UtcNow(),
            };
            repository.AddTransaction(expectedTransaction.account_id, expectedTransaction.amount);
            var transaction = repository.GetTransactionById(expectedTransaction.transaction_id);
            transaction.Should().BeEquivalentTo(expectedTransaction);
        }

        [Test]
        public void ReturnAnAccountSummaryForAnExistingAccount()
        {
            var testableDateTimeProvider = new TestableDateTimeProvider();
            var testableTransactionIdProvider = new TestableTransactionIdProvider();
            var repository = new TransactionsRepository(
                testableDateTimeProvider,
                testableTransactionIdProvider);
            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();
            repository.AddTransaction(accountId1, 100);
            repository.AddTransaction(accountId1, 150);
            repository.AddTransaction(accountId2, 150);

            var result = repository.GetAllTransactionsForAccount(accountId1);
            result.Should().NotBeNull();
            result.account_id.Should().Be(accountId1);
            result.balance.Should().Be(250);
        }

        [Test]
        public void ReturnNullForAnInvalidAccount()
        {
            var testableDateTimeProvider = new TestableDateTimeProvider();
            var testableTransactionIdProvider = new TestableTransactionIdProvider();
            var repository = new TransactionsRepository(
                testableDateTimeProvider,
                testableTransactionIdProvider);
            var accountId = Guid.NewGuid();

            var result = repository.GetAllTransactionsForAccount(accountId);
            result.Should().BeNull();



        }
    }
}
