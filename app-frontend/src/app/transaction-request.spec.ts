import { TransactionRequest } from './transaction-request';

describe('TransactionRequest', () => {
  it('should create an instance', () => {
    expect(new TransactionRequest("ACCOUNTID", "10")).toBeTruthy();
  });
});
