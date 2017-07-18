using System;
namespace LogicBook.ConsoleUI
{
	public class ComparerByAuthor : IBookComparer
	{
		public int Compare(Book lhs, Book rhs)
		{
			if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
			if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

			return lhs.Author.CompareTo(rhs.Author);
		} 
	}
}
