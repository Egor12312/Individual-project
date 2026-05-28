using OnlineBookstore.Interfaces;

namespace OnlineBookstore.PaymentMethods {
  public class YooMoneyPayment : IPaymentMethod {
    private readonly string yooMoneyEmail;

    public YooMoneyPayment(string email) {
      yooMoneyEmail = email;
    }

    public void Pay(double amount) {
      string paymentMessage;

      paymentMessage = "Paid " + amount + " rub. using YooMoney (account: " + yooMoneyEmail + ")";
      return;
    }
  }
}