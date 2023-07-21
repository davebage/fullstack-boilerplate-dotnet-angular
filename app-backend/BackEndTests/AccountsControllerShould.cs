using backend.Controllers;
using backend.Models;
using backend.Providers;
using backend.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BackEndTests;

[TestFixture]
public class AccountsControllerShould
{
    [Test]
    public void ReturnNotFoundWhenInvalidAccountIdOnGet()
    {
        var repository = new TransactionsRepository(new DateTimeProvider(), new TransactionIdProvider());
        var accountId = Guid.NewGuid();
        repository.AddTransaction(accountId, 100);
        var controller = new AccountsController(repository);
        var result = controller.GetAccountData(Guid.Empty);

        result.Should().BeAssignableTo<NotFoundObjectResult>();
        var objectResult = (NotFoundObjectResult) result;
        objectResult.Value.Should().Be("Account not found");
    }

    [Test]
    public void ReturnOkResultWhenValidAccountIdOnGet()
    {
        var repository = new TransactionsRepository(new DateTimeProvider(), new TransactionIdProvider());
        var mockRepository = new Mock<ITransactionsRepository>();
        var accountId = Guid.NewGuid();
        const int accountSum = 100;
        mockRepository.Setup(x => x.GetAllTransactionsForAccount(It.IsAny<Guid>()))
            .Returns(new Account(accountId, accountSum));

        var controller = new AccountsController(mockRepository.Object);
        var result = controller.GetAccountData(Guid.Empty);
        result.Should().BeAssignableTo<OkObjectResult>();
        var okResultValue = ((OkObjectResult) result).Value as Account;

        okResultValue.Should().NotBeNull();
        okResultValue.account_id.Should().Be(accountId);
        okResultValue.balance.Should().Be(accountSum);

    }
}