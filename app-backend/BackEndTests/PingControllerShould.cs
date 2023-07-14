using backend.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTests
{
    [TestFixture]
    public class PingControllerShould
    {
        [Test]
        public void ReturnOkResultOnGet()
        {
            var controller = new PingController();
            controller.Get().Should().BeAssignableTo<OkResult>();
        }
    }
}