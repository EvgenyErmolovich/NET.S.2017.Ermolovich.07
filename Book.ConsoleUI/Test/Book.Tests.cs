using System;

namespace LogicBook.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			Book b1 = new Book();
			b1.Name = "aaaaaa";
			b1.Author = "a";
			b1.Pages = 3;
			b1.Year = 1045;
			Book b2 = new Book();
			b2.Name = "ccccc";
			b2.Author = "c";
			b2.Pages = 2;
			b2.Year = 1055;
			Book b3 = new Book();
			b3.Name = "bbbbb";
			b3.Author = "b";
			b3.Pages = 4;
			b3.Year = 1655;
			BookListService service = new BookListService();
			service.AddBook(b1);
			service.AddBook(b2);
			service.AddBook(b3);
			Console.WriteLine(service);
			service.SortBooksByTag(new ComparerByAuthor());
			Console.WriteLine(service);
		}
	}
}
