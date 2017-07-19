using System;
namespace LogicBook
{
	public class Book : IEquatable<Book>, IComparable, IComparable<Book>
	{
		private static int minYear = 1000;
		private static int maxYear = DateTime.Today.Year;
		private static int minPages = 1;
		private static int maxPages = 1000;
		/// <summary>
		/// The name.
		/// </summary>
		private string name;
		/// <summary>
		/// The author.
		/// </summary>
		private string author;
		/// <summary>
		/// The year.
		/// </summary>
		private int year;
		/// <summary>
		/// The pages.
		/// </summary>
		private int pages;
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
		/// Compares to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="other">Other.</param>
		public int CompareTo(Book other) => other.Pages - Pages;
		/// <summary>
		/// Compares to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="obj">Object.</param>
		public int CompareTo(object obj)
		{
			if ((ReferenceEquals(obj, null)) || typeof(Book) == obj.GetType()) throw new ArgumentNullException($"{nameof(obj)} is invalid!");
			return this.CompareTo(obj as Book);
		}
		/// <summary>
		/// Determines whether the specified <see cref="LogicBook.Book"/> is equal to the current <see cref="T:LogicBook.Book"/>.
		/// </summary>
		/// <param name="other">The <see cref="LogicBook.Book"/> to compare with the current <see cref="T:LogicBook.Book"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="LogicBook.Book"/> is equal to the current <see cref="T:LogicBook.Book"/>;
		/// otherwise, <c>false</c>.</returns>
		public bool Equals(Book other)
		{
			if (ReferenceEquals(other, null)) return false;
			return ((Name == other.Name) && (Author == other.Author) && (Year == other.Year) && (Pages == other.Pages));
		}
		/// <summary>
		/// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:LogicBook.Book"/>.
		/// </summary>
		/// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:LogicBook.Book"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:LogicBook.Book"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if ((ReferenceEquals(obj, null)) || typeof(Book) == obj.GetType()) return false;
			return Equals(obj as Book);
		}
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
