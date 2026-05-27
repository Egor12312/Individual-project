using System;
using System.Collections.Generic;
using OnlineBookstore.Core;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;
using OnlineBookstore.PaymentMethods;

namespace OnlineBookstore.Program {
  public class Program {
    public static void Main(string[] args) {
      string checkoutResult;
      List<Book> bookCatalog = new List<Book>();

      Book firstBook = new Book("The Hobbit", "J.R.R. Tolkien", 450.0);
      Book secondBook = new Book("1984", "George Orwell", 320.0);
      Book thirdBook = new Book("Clean Code", "Robert Martin", 890.0);

      bookCatalog.Add(firstBook);
      bookCatalog.Add(secondBook);
      bookCatalog.Add(thirdBook);

      Order currentOrder = new Order();

      bool isShopping = true;

      while (isShopping) {
        Console.WriteLine("\n===== ONLINE BOOKSTORE =====");
        Console.WriteLine("1 - Show catalog");
        Console.WriteLine("2 - Add book to cart");
        Console.WriteLine("3 - Show cart and checkout");
        Console.WriteLine("4 - Exit");
        Console.Write("Your choice: ");

        string userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out int userChoice)) {
          Console.WriteLine("Please enter a number.");
          continue;
        }

        if (userChoice == 1) {
          Console.WriteLine("\nAvailable books:");
          for (int bookIndex = 0; bookIndex < bookCatalog.Count; ++bookIndex) {
            Console.Write(bookIndex + 1 + ". ");
            Console.WriteLine(bookCatalog[bookIndex].GetDisplayInfo());
          }
        } else if (userChoice == 2) {
          Console.Write("Enter book number from catalog: ");
          string bookNumberInput = Console.ReadLine();
          if (!int.TryParse(bookNumberInput, out int bookIndexForOrder)) {
            Console.WriteLine("Invalid number.");
            continue;
          }

          int realBookIndex = bookIndexForOrder - 1;

          if (realBookIndex >= 0 && realBookIndex < bookCatalog.Count) {
            Book selectedBook = bookCatalog[realBookIndex];
            currentOrder.AddBook(selectedBook);
            Console.WriteLine("Added \"" + selectedBook.GetTitle() + "\" to cart.");
          } else {
            Console.WriteLine("Book not found.");
          }
        } else if (userChoice == 3) {
          Console.WriteLine("\nSelect payment method:");
          Console.WriteLine("1 - Credit Card");
          Console.WriteLine("2 - YooMoney");
          Console.Write("Enter 1 or 2: ");

          string paymentInput = Console.ReadLine();
          if (!int.TryParse(paymentInput, out int paymentMethodIndex)) {
            Console.WriteLine("Invalid payment choice.");
            continue;
          }

          if (paymentMethodIndex == 1) {
            Console.Write("Enter card number (16 digits): ");
            string cardNum = Console.ReadLine();
            Console.Write("Enter cardholder name: ");
            string holder = Console.ReadLine();

            IPaymentMethod creditMethod = new CreditCardPayment(cardNum, holder);
            currentOrder.SetPaymentMethod(creditMethod);
          } else if (paymentMethodIndex == 2) {
            Console.Write("Enter your YooMoney email: ");
            string email = Console.ReadLine();

            IPaymentMethod yooMethod = new YooMoneyPayment(email);
            currentOrder.SetPaymentMethod(yooMethod);
          } else {
            Console.WriteLine("Wrong payment method.");
            continue;
          }

          checkoutResult = currentOrder.Checkout();
          Console.WriteLine(checkoutResult);
        } else if (userChoice == 4) {
          isShopping = false;
          Console.WriteLine("Goodbye!");
        } else {
          Console.WriteLine("Incorrect option. Choose 1-4.");
        }
      }
    }
  }
}