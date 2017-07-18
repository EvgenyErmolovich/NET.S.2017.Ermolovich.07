using System;
namespace LogicBook
{
	public class Book : IEquatable<Book>
	{
		/// <summary>
		/// The name.
		/// </summary>
		private string name;
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
				name = value;
			}
		}
		/// <summary>
		/// The author.
		/// </summary>
		private string author;
		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		/// <value>The author.</value>
		public string Author
		{
			get { return author; }
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
				author = value;
			}
		}
		/// <summary>
		/// The year.
		/// </summary>
		private int year;
		/// <summary>
		/// The minimum year.
		/// </summary>
		private static int minYear = 1000;
		private static int maxYear = DateTime.Today.Year;
		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year
		{
			get { return year; }
			set
			{
				if (value < minYear || value > maxYear) throw new ArgumentException($"{nameof(value)} is invalid!");
				year = value;
			}

		}
		/// <summary>
		/// The pages.
		/// </summary>
		private int pages;
		private static int minPages = 1;
		private static int maxPages = 1000;
		/// <summary>
		/// Gets or sets the pages.
		/// </summary>
		/// <value>The pages.</value>
		public int Pages
		{
			get { return pages; }
			set
			{
				if (value < minPages || value > maxPages) throw new ArgumentException($"{nameof(value)} is invalid!");
				pages = value;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicBook.Book"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="author">Author.</param>
		/// <param name="year">Year.</param>
		/// <param name="pages">Pages.</param>
		public Book(string name, string author, int year, int pages)
		{
			Name = name;
			Author = author;
			Year = year;
			Pages = pages;
		}
		/// <summary>
		/// Compare the specified lhs, rhs and comparer.
		/// </summary>
		/// <returns>The compare.</returns>
		/// <param name="lhs">Lhs.</param>
		/// <param name="rhs">Rhs.</param>
		/// <param name="comparer">Comparer.</param>
		public static int Compare(Book lhs, Book rhs, IBookComparer comparer) => comparer.Compare(lhs, rhs);
		/// <summary>
		/// Determines whether the specified <see cref="LogicBook.Book"/> is equal to the current <see cref="T:LogicBook.Book"/>.
		/// </summary>
		/// <param name="other">The <see cref="LogicBook.Book"/> to compare with the current <see cref="T:LogicBook.Book"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="LogicBook.Book"/> is equal to the current <see cref="T:LogicBook.Book"/>;
		/// otherwise, <c>false</c>.</returns>
		public bool Equals(Book other) => (!ReferenceEquals(other, null))? 
		((Name == other.Name) && (Author == other.Author) && (Year == other.Year) && (Pages == other.Pages)) : false;
		/// <summary>
		/// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:LogicBook.Book"/>.
		/// </summary>
		/// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:LogicBook.Book"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:LogicBook.Book"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => (!(ReferenceEquals(obj, null)) || typeof(Book) == obj.GetType())?
		Equals(obj as Book) : false;
		/// <summary>
		/// Serves as a hash function for a <see cref="T:LogicBook.Book"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() => Pages.GetHashCode() + Year.GetHashCode() + Author.GetHashCode() + Name.GetHashCode();
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.Book"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:LogicBook.Book"/>.</returns>
		public override string ToString() => $"Book: \"{Name}\", author: {Author}, year of publishing: {Year}, {Pages} pages";
	}
}
