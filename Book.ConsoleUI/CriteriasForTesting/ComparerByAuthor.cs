using System;
using System.Collections.Generic;
namespace LogicBook.ConsoleUI
{
	public class ComparerByAuthor : IComparer<Book>
	{
		public int Compare(Book lhs, Book rhs)
		{
			if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
			if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

			return lhs.Author.CompareTo(rhs.Author);
		} 
	}
}
