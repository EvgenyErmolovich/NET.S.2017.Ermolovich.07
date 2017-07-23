using System;
using System.Collections;
using System.Collections.Generic;
using System.Text; 
namespace LogicBook
{
	public class BookListService
	{
		/// <summary>
		/// The book list.
		/// </summary>
		private List<Book> bookList;
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.BookListService"/> class.
		/// </summary>
		public BookListService()
		{
			bookList = new List<Book>();
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.BookListService"/> class.
		/// </summary>
		/// <param name="bookList">Book list.</param>
		public BookListService(IEnumerable<Book> bookList):this()
		{
			if (bookList == null) throw new ArgumentNullException($"{nameof(bookList)} is invalid!");
			foreach (var book in bookList)
				AddBook(book);
		}
		/// <summary>
		/// Adds the book.
		/// </summary>
		/// <param name="book">Book.</param>
		public void AddBook(Book book)
		{
			if (book == null) throw new ArgumentNullException($"{nameof(book)} is invalid!");
			if (bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} exist!");
			bookList.Add(book);
		}
		/// <summary>
		/// Removes the book.
		/// </summary>
		/// <param name="book">Book.</param>
		public void RemoveBook(Book book)
		{
			if (!bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} does not exist!");
			bookList.Remove(book);
		}
		/// <summary>
		/// Finds the book by tag.
		/// </summary>
		/// <returns>The book by tag.</returns>
		/// <param name="finder">Finder.</param>
		public Book FindBookByTag(IFinder finder)
		{
			foreach (var book in bookList)
			{
				if (finder.Find(book)) return book;
			}
			return null;
		}
		/// <summary>
		/// Sorts the books by tag.
		/// </summary>
		/// <param name="comparer">Comparer.</param>
		public void SortBooksByTag(IComparer<Book> comparer)
		{
			bookList.Sort(comparer);
		}
		/// <summary>
		/// Saves to storage.
		/// </summary>
		/// <param name="storage">Storage.</param>
		public void SaveToStorage(IBookStorage storage)
		{
			if (storage == null) throw new ArgumentNullException($"{nameof(storage)} is invalid!");
			storage.WriteToStorage(bookList);
		}
		/// <summary>
		/// Loads from storage.
		/// </summary>
		/// <param name="storage">Storage.</param>
		public void LoadFromStorage(IBookStorage storage)
		{
			if (storage == null) throw new ArgumentNullException($"{nameof(storage)} is invalid!");
			bookList = new List<Book>(storage.ReadFromStorage());
		}
		/// <summary>
		/// Gets the <see cref="T:LogicBook.BookListService"/> with the specified i.
		/// </summary>
		/// <param name="i">The index.</param>
		public Book this[int i] => bookList[i];
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.BookListService"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.BookListService"/>.</returns>
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();
			str.Append("List of books:\n");
			foreach (Book book in bookList)
			{
				str.Append(book);
				str.Append('\n');
			}
			str.Append("\n");
			return str.ToString();
		}
	 }
}
