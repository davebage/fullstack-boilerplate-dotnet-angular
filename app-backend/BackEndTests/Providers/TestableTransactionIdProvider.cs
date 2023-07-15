using backend.Providers;

namespace BackEndTests.Providers;

public class TestableTransactionIdProvider : TransactionIdProvider
{
    protected override Guid GetTransactionId() =>
        new Guid("4bcc3959-6fe1-406e-9f04-cad2637b47d5");
}