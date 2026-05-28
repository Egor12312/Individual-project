using OnlineBookstore.Interfaces;

namespace OnlineBookstore.PaymentMethods {
  public class CreditCardPayment : IPaymentMethod {
    private readonly string cardNumber;
    private readonly string cardHolderName;

    public CreditCardPayment(string number, string holderName) {
      cardNumber = number;
      cardHolderName = holderName;
    }

    public void Pay(double amount) {
      string lastFourDigits;
      string paymentMessage;
      int lastDigitsCount;

      lastDigitsCount = 4;
      lastFourDigits = cardNumber.Substring(cardNumber.Length - lastDigitsCount);
      paymentMessage = "Paid " + amount + " rub. using Credit Card (" + cardHolderName + ", card: ****" + lastFourDigits + ")";
      return;
    }
  }
}