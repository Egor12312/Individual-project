namespace OnlineBookstore.PaymentMethods {
  using System;
  using OnlineBookstore.Interfaces;

  public class YooMoneyPayment : IPaymentMethod {
    private string yooMoneyEmail;

    public YooMoneyPayment(string email) {
      this.yooMoneyEmail = email;
    }

    public string Pay(double amount) {
      string paymentMessage;

      paymentMessage = "Paid " + amount + " rub. using YooMoney (account: " + this.yooMoneyEmail + ")";

      return paymentMessage;
    }
  }
}