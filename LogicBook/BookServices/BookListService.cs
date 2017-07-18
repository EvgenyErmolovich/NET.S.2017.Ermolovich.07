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
		/// Gets or sets the book list.
		/// </summary>
		/// <value>The book list.</value>
		private List<Book> BookList 
		{ 
			get { return bookList; }
			set 
			{
				if (value == null) throw new ArgumentNullException($"{nameof(value)} is invalid!");
				else
				{
					bookList = new List<Book>();
					foreach (var book in value)
					AddBook(book);
				}
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.BookListService"/> class.
		/// </summary>
		public BookListService()
		{
			BookList = new List<Book>();
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.BookListService"/> class.
		/// </summary>
		/// <param name="bookList">Book list.</param>
		public BookListService(List<Book> bookList)
		{
			BookList = bookList;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.BookListService"/> class.
		/// </summary>
		/// <param name="storage">Storage.</param>
		public BookListService(IBookStorage storage)
		{
			LoadFromStorage(storage);
		}
		/// <summary>
		/// Adds the book.
		/// </summary>
		/// <param name="book">Book.</param>
		public void AddBook(Book book)
		{
			if (book == null) throw new ArgumentNullException($"{nameof(book)} is invalid!");
			if (BookList.Contains(book)) throw new ArgumentException($"{nameof(book)} exist!");
			bookList.Add(book);
		}
		/// <summary>
		/// Removes the book.
		/// </summary>
		/// <param name="book">Book.</param>
		public void RemoveBook(Book book)
		{
			if (!BookList.Contains(book)) throw new ArgumentException($"{nameof(book)} does not exist!");
			BookList.Remove(book);
		}
		/// <summary>
		/// Finds the book by tag.
		/// </summary>
		/// <returns>The book by tag.</returns>
		/// <param name="finder">Finder.</param>
		public Book FindBookByTag(IFinder finder)
		{
			foreach (var book in BookList)
			{
				if (finder.Find(book)) return book;
			}
			return null;
		}
		/// <summary>
		/// Sorts the books by tag.
		/// </summary>
		/// <param name="comparer">Comparer.</param>
		public void SortBooksByTag(IBookComparer comparer)
		{
			Book temp = null;
			Book[] array = bookList.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j<array.Length-1; j++)
                {
                    if(comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
			bookList.Clear();
			for (int i = 0; i < array.Length; i++)
			{

				this.AddBook(array[i]);
			}
		}
		/// <summary>
		/// Saves to storage.
		/// </summary>
		/// <param name="storage">Storage.</param>
		public void SaveToStorage(IBookStorage storage)
		{
			storage.WriteToStorage(BookList);
		}
		/// <summary>
		/// Loads from storage.
		/// </summary>
		/// <param name="storage">Storage.</param>
		public void LoadFromStorage(IBookStorage storage)
		{
			BookList = storage.ReadFromStorage();
		}
		/// <summary>
		/// Gets the <see cref="T:LogicBook.BookListService"/> with the specified i.
		/// </summary>
		/// <param name="i">The index.</param>
		public Book this[int i] => BookList[i];
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.BookListService"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.BookListService"/>.</returns>
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();
			str.Append("List of books:\n");
			foreach (Book book in BookList)
			{
				str.Append(book);
				str.Append('\n');
			}
			str.Append("\n");
			return str.ToString();
		}
	 }
}
