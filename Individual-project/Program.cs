using System;
using System.Collections.Generic;
using OnlineBookstore.Core;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;
using OnlineBookstore.PaymentMethods;

namespace OnlineBookstore.Program {
  public class Program {
    public static void Main() {
      int firstBookPrice, secondBookPrice, thirdBookPrice, menuOptionShowCatalog, menuOptionAddBook;
      int menuOptionCheckout, menuOptionExit, paymentMethodCreditCard, paymentMethodYooMoney;
      int catalogStartIndex, numberZero, cardNumberLength;
      string checkoutResult, optionsRange, errorMessage, email, holder, cardNum, paymentInput;
      List<Book> bookCatalog;
      Book firstBook;
      Book secondBook;
      Book thirdBook;
      Order currentOrder;
      bool isShopping;
      string userInput, displayNumberText, bookNumberInput;
      int displayNumber, realBookIndex;

      firstBookPrice = 450;
      secondBookPrice = 320;
      thirdBookPrice = 890;
      menuOptionShowCatalog = 1;
      menuOptionAddBook = 2;
      menuOptionCheckout = 3;
      menuOptionExit = 4;
      paymentMethodCreditCard = 1;
      paymentMethodYooMoney = 2;
      catalogStartIndex = 1;
      numberZero = 0;
      cardNumberLength = 16;

      bookCatalog = new List<Book>();
      firstBook = new Book("The Hobbit", "J.R.R. Tolkien", firstBookPrice);
      secondBook = new Book("1984", "George Orwell", secondBookPrice);
      thirdBook = new Book("Clean Code", "Robert Martin", thirdBookPrice);

      bookCatalog.Add(firstBook);
      bookCatalog.Add(secondBook);
      bookCatalog.Add(thirdBook);

      currentOrder = new Order();
      isShopping = true;

      while (isShopping) {
        Console.WriteLine("\n===== ONLINE BOOKSTORE =====");
        Console.WriteLine(menuOptionShowCatalog + " - Show catalog");
        Console.WriteLine(menuOptionAddBook + " - Add book to cart");
        Console.WriteLine(menuOptionCheckout + " - Show cart and checkout");
        Console.WriteLine(menuOptionExit + " - Exit");
        Console.Write("Your choice: ");

        userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out int userChoice)) {
          Console.WriteLine("Please enter a number.");
          continue;
        }

        if (userChoice == menuOptionShowCatalog) {
          Console.WriteLine("\nAvailable books:");

          for (int bookIndex = 0; bookIndex < bookCatalog.Count; ++bookIndex) {
            displayNumber = bookIndex + catalogStartIndex;
            displayNumberText = displayNumber + ". ";
            Console.Write(displayNumberText);
            Console.WriteLine(bookCatalog[bookIndex].GetDisplayInfo());
          }
        } else if (userChoice == menuOptionAddBook) {
          Console.Write("Enter book number from catalog: ");

          bookNumberInput = Console.ReadLine();
          if (!int.TryParse(bookNumberInput, out int bookIndexForOrder)) {
            Console.WriteLine("Invalid number.");
            continue;
          }

          realBookIndex = bookIndexForOrder - catalogStartIndex;

          if (realBookIndex >= numberZero && realBookIndex < bookCatalog.Count) {
            Book selectedBook;
            selectedBook = bookCatalog[realBookIndex];
            currentOrder.AddBook(selectedBook);
            Console.WriteLine("Added \"" + selectedBook.GetTitle() + "\" to cart.");
          } else {
            Console.WriteLine("Book not found.");
          }
        } else if (userChoice == menuOptionCheckout) {
          Console.WriteLine("\nSelect payment method:");
          Console.WriteLine(paymentMethodCreditCard + " - Credit Card");
          Console.WriteLine(paymentMethodYooMoney + " - YooMoney");
          Console.Write("Enter 1 or 2: ");

          paymentInput = Console.ReadLine();
          if (!int.TryParse(paymentInput, out int paymentMethodIndex)) {
            Console.WriteLine("Invalid payment choice.");
            continue;
          }

          if (paymentMethodIndex == paymentMethodCreditCard) {
            IPaymentMethod creditMethod;

            Console.Write("Enter card number (" + cardNumberLength + " digits): ");
            cardNum = Console.ReadLine();
            Console.Write("Enter cardholder name: ");
            holder = Console.ReadLine();

            creditMethod = new CreditCardPayment(cardNum, holder);
            currentOrder.SetPaymentMethod(creditMethod);
          } else if (paymentMethodIndex == paymentMethodYooMoney) {
            IPaymentMethod yooMethod;

            Console.Write("Enter your YooMoney email: ");
            email = Console.ReadLine();

            yooMethod = new YooMoneyPayment(email);
            currentOrder.SetPaymentMethod(yooMethod);
          } else {
            Console.WriteLine("Wrong payment method.");
            continue;
          }

          checkoutResult = currentOrder.Checkout();
          Console.WriteLine(checkoutResult);
        } else if (userChoice == menuOptionExit) {
          isShopping = false;
          Console.WriteLine("Goodbye!");
        } else {
          optionsRange = menuOptionShowCatalog + "-" + menuOptionExit;
          errorMessage = "Incorrect option. Choose " + optionsRange + ".";
          Console.WriteLine(errorMessage);
        }
      }
    }
  }
}