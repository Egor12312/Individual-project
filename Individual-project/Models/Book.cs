namespace OnlineBookstore.Models {
  public class Book {
    private readonly string bookTitle;
    private readonly string bookAuthor;
    private readonly double bookPrice;

    public Book(string title, string author, double price) {
      bookTitle = title;
      bookAuthor = author;
      bookPrice = price;
    }

    public string GetTitle() {
      return bookTitle;
    }

    public string GetAuthor() {
      return bookAuthor;
    }

    public double GetPrice() {
      return bookPrice;
    }

    public string GetDisplayInfo() {
      string info;

      info = "\"" + bookTitle + "\" by " + bookAuthor + " — " + bookPrice + " rub.";

      return info;
    }
  }
}