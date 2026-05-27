namespace OnlineBookstore.Core {
  using System.Collections.Generic;
  using OnlineBookstore.Interfaces;
  using OnlineBookstore.Models;

  public class Order {
    private List<Book> orderedBooks;
    private IPaymentMethod selectedPaymentMethod;

    public Order() {
      this.orderedBooks = new List<Book>();
    }

    public void AddBook(Book book) {
      this.orderedBooks.Add(book);
    }

    public void SetPaymentMethod(IPaymentMethod method) {
      this.selectedPaymentMethod = method;
    }

    private double CalculateTotal() {
      double totalSum;

      totalSum = 0.0;

      for (int bookIndex = 0; bookIndex < this.orderedBooks.Count; bookIndex++) {
        totalSum = totalSum + this.orderedBooks[bookIndex].GetPrice();
      }

      return totalSum;
    }

    private string Checkout() {
      string resultMessage;

      if (this.orderedBooks.Count == 0) {
        resultMessage = "Your cart is empty. Add books before checkout.";
        return resultMessage;
      }

      if (this.selectedPaymentMethod == null) {
        resultMessage = "No payment method selected.";
        return resultMessage;
      }

      double finalAmount = this.CalculateTotal();
      string paymentResult = this.selectedPaymentMethod.Pay(finalAmount);

      resultMessage = "\nOrder total: " + finalAmount + " rub.\n" + paymentResult + "\nPurchase completed! Thank you for shopping.\n";

      this.orderedBooks.Clear();

      return resultMessage;
    }
  }
}