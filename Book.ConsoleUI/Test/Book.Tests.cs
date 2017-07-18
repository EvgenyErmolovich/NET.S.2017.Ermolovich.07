using System;

namespace LogicBook.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			Book b1 = new Book("aaa-name", "bbb-author", 2012, 25);
			Book b2 = new Book("ffff-name", "wwwww-author", 2012, 832);
			Book b3 = new Book("cccc-name", "ggggg-author", 1900, 129);

			Console.WriteLine(Book.Compare(b1, b2, new ComparerByAuthor()));
			Console.WriteLine(b1.Equals(b3));

			BookListService service = new BookListService();
			service.AddBook(b1); 
			service.AddBook(b2); 
			service.AddBook(b3);
			service.RemoveBook(b1);
			Console.WriteLine(service);
			Console.WriteLine(service.FindBookByTag(new FinderByAuthor("bbb-author")));

			service.SortBooksByTag(new ComparerByAuthor());
			Console.WriteLine(service);

		}
	}
}