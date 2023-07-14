using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTests
{
    [TestFixture]
    public class TransactionsControllerShould
    {
        [Test]
        public void ReturnNotFoundStatusForInvalidTransactionId()
        {
            var controller = new TransactionsController();

            var result = controller.GetTransactionForId(Guid.Empty);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
            ((NotFoundObjectResult)result).Value.Should().Be("Transaction not found");
        }
    }
}
