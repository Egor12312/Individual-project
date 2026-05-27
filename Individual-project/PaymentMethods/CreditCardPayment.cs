namespace OnlineBookstore.PaymentMethods {
  using System;
  using OnlineBookstore.Interfaces;

  public class CreditCardPayment : IPaymentMethod {
    private string cardNumber;
    private string cardHolderName;

    public CreditCardPayment(string number, string holderName) {
      this.cardNumber = number;
      this.cardHolderName = holderName;
    }

    public void Pay(double amount) {
      string lastFourDigits = this.cardNumber.Substring(this.cardNumber.Length - 4);
      Console.WriteLine("Paid " + amount + " rub. using Credit Card (" + this.cardHolderName + ", card: ****" + lastFourDigits + ")");
    }
  }
}