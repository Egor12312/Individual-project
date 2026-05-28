using System.Collections.Generic;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;

namespace OnlineBookstore.Core {
  public class Order {
    private readonly List<Book> orderedBooks;
    private IPaymentMethod selectedPaymentMethod;

    public Order() {
      orderedBooks = new List<Book>();
    }

    public void AddBook(Book book) {
      orderedBooks.Add(book);
    }

    public void SetPaymentMethod(IPaymentMethod method) {
      selectedPaymentMethod = method;
    }

    private double CalculateTotal() {
      double totalSum;

      totalSum = 0.0;

      for (int bookIndex = 0; bookIndex < orderedBooks.Count; ++bookIndex) {
        totalSum += orderedBooks[bookIndex].GetPrice();
      }

      return totalSum;
    }

    public string Checkout() {
      string resultMessage;
      double finalAmount;

      if (orderedBooks.Count == 0) {
        resultMessage = "Your cart is empty. Add books before checkout.";
        return resultMessage;
      }

      if (selectedPaymentMethod == null) {
        resultMessage = "No payment method selected.";
        return resultMessage;
      }

      finalAmount = CalculateTotal();
      selectedPaymentMethod.Pay(finalAmount);

      resultMessage = "\nOrder total: " + finalAmount + " rub.\n" + "\nPurchase completed! Thank you for shopping.\n";

      orderedBooks.Clear();

      return resultMessage;
    }
  }
}