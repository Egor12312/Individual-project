namespace OnlineBookstore.PaymentMethods {
  using System;
  using OnlineBookstore.Interfaces;

  public class CreditCardPayment : IPaymentMethod {
    private string cardNumber;
    private string cardHolderName;
    private const int lastDigitsCount = 4;

    public CreditCardPayment(string number, string holderName) {
      this.cardNumber = number;
      this.cardHolderName = holderName;
    }

    public string Pay(double amount) {
      string lastFourDigits;
      string paymentMessage;

      lastFourDigits = this.cardNumber.Substring(this.cardNumber.Length - lastDigitsCount);
      paymentMessage = "Paid " + amount + " rub. using Credit Card (" + this.cardHolderName + ", card: ****" + lastFourDigits + ")";

      return paymentMessage;
    }
  }
}