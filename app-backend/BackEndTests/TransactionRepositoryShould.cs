using backend.Controllers;
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
    }
}
