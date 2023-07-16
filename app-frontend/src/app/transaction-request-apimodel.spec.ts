import { TransactionRequestAPIModel } from './transaction-request-apimodel';

describe('TransactionRequestAPIModel', () => {
  it('should create an instance', () => {
    expect(new TransactionRequestAPIModel("TESTACCOUNTID",10)).toBeTruthy();
  });
});
