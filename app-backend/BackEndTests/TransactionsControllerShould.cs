using backend.Controllers;
using BackEndTests.Providers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BackEndTests
{
    [TestFixture]
    public class TransactionsControllerShould
    {
        [Test]
        public void ReturnNotFoundStatusForInvalidTransactionId()
        {
            var mockDateTimeProvider = new Mock<DateTimeProvider>().Object;
            var mockTransactionIdProvider = new Mock<TransactionIdProvider>().Object;
            var mockedRepository = new Mock<TransactionsRepository>(
                mockDateTimeProvider, 
                mockTransactionIdProvider);

            var controller = new TransactionsController(mockedRepository.Object);

            var result = controller.GetTransactionForId(Guid.Empty);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
            ((NotFoundObjectResult)result).Value.Should().Be("Transaction not found");
        }

        [Test]
        public void ReturnOkWithTransactionForValidTransactionIdOnGet()
        {
            var validTransactionId = new Guid("4bcc3959-6fe1-406e-9f04-cad2637b47d5");
            var mockedRepository = new Mock<ITransactionsRepository>();
            mockedRepository.Setup(m => 
                m.GetTransactionById(It.IsAny<Guid>())).Returns(new Transaction
            {
                transaction_id = validTransactionId
            });
            var controller = new TransactionsController(mockedRepository.Object);
            var result = controller.GetTransactionForId(validTransactionId);
            result.Should().BeAssignableTo<OkObjectResult>();
            var okresultValue = (OkObjectResult)result;
            okresultValue.Value.Should().BeAssignableTo<Transaction>();
        }

        [Test]
        public void ReturnArrayOfTransactionsOnGet()
        {
            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();
            var accountId3 = Guid.NewGuid();
            var repository = new TransactionsRepository(new DateTimeProvider(), new TransactionIdProvider());
            repository.AddTransaction(accountId1, 100);
            repository.AddTransaction(accountId2, 200);
            repository.AddTransaction(accountId3, 300);

            var controller = new TransactionsController(repository);

            var result = controller.GetTransactions();
            result.Should().BeAssignableTo<OkObjectResult>();
            var resultValue = (OkObjectResult)result;
            resultValue.Value.Should().BeAssignableTo<Transaction[]>();
            var transactionArray = resultValue.Value as Transaction[];
            transactionArray.Length.Should().Be(3);
            transactionArray[0].account_id.Should().Be(accountId3);
            transactionArray[1].account_id.Should().Be(accountId2);
            transactionArray[2].account_id.Should().Be(accountId1);
        }

        [Test]
        public void ReturnCreatedStatusWithTransactionObjectOnPost()
        {
            var transactionIdProvider = new TestableTransactionIdProvider();
            var dateTimeProvider = new TestableDateTimeProvider();
            var controller = new TransactionsController(new TransactionsRepository(dateTimeProvider, transactionIdProvider));
            var transactionRequest = new TransactionRequest
            {
                account_id = Guid.NewGuid(),
                amount = 100
            };
            var result = controller.CreateTransaction(transactionRequest);

            var expectedTransaction = new Transaction
            {
                transaction_id = transactionIdProvider.NewTransactionId(),
                created_at = dateTimeProvider.UtcNow(),
                amount = transactionRequest.amount,
                account_id = transactionRequest.account_id
            };
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            var createdResult = ((CreatedAtActionResult)result).Value as Transaction;
            createdResult.Should().NotBeNull();
            createdResult.Should().BeEquivalentTo(expectedTransaction);
        }
    }
}