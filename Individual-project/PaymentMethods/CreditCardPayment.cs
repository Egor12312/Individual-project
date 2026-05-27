namespace OnlineBookstore.PaymentMethods {
  using System;
  using OnlineBookstore.Interfaces;

  public class CreditCardPayment : IPaymentMethod {
    private string cardNumber;
    private string cardHolderName;
    private int lastDigitsCount = 4;

    public CreditCardPayment(string number, string holderName) {
      this.cardNumber = number;
      this.cardHolderName = holderName;
    }

    public void Pay(double amount) {
      string lastFourDigits;

      lastFourDigits = this.cardNumber.Substring(this.cardNumber.Length - lastDigitsCount);

      Console.WriteLine("Paid " + amount + " rub. using Credit Card (" + this.cardHolderName + ", card: ****" + lastFourDigits + ")");
    }
  }
}