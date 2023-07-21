import { Transaction } from './transaction';

describe('Transaction', () => {
  it('should create an instance', () => {
    expect(new Transaction("TRANSACTIONID", "ACCOUNTID", 10, new Date())).toBeTruthy();
  });
});
