namespace OnlineBookstore.Models {
  using System;

  public class Book {
    private string bookTitle;
    private string bookAuthor;
    private double bookPrice;

    public Book(string title, string author, double price) {
      this.bookTitle = title;
      this.bookAuthor = author;
      this.bookPrice = price;
    }

    public string GetTitle() {
      return this.bookTitle;
    }

    public string GetAuthor() {
      return this.bookAuthor;
    }

    public double GetPrice() {
      return this.bookPrice;
    }

    public string DisplayInfo() {
      string info;

      info = "\"" + this.bookTitle + "\" by " + this.bookAuthor + " — " + this.bookPrice + " rub.";

      return info;
    }
  }
}