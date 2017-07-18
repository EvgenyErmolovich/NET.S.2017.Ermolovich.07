using System;
namespace LogicBook.ConsoleUI
{
	public class FinderByAuthor : IFinder
	{
		private string author;

		public FinderByAuthor(string author)
		{
			if (string.IsNullOrEmpty(author)) throw new ArgumentNullException($"{nameof(author)} is invalid!");
			this.author = author;
		}

		public bool Find(Book book)
		{
			if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is invalid!");
			return book.Author == author;
		} 
	}
}
