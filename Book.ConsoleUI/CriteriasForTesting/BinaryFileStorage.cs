using System;
using System.Collections.Generic;
using System.IO;
namespace LogicBook.ConsoleUI
{
	public class BinaryFileStorage : IBookStorage
	{
		private string fileName;
		public string FileName
		{ 
			get { return fileName; }
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
				fileName = value;
			}
		}

		public BinaryFileStorage(string fileName)
		{
			FileName = fileName;
		}

		public List<Book> ReadFromStorage()
		{
			List<Book> bookList = new List<Book>();
			using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
			{
				while (reader.PeekChar() > -1)
				{
					Book temp = new Book();
					temp.Name = reader.ReadString();
					temp.Author = reader.ReadString();
					temp.Year = reader.ReadInt32();
					temp.Pages = reader.ReadInt32();
					bookList.Add(temp);
				}
			}
			return bookList;
		}

		public void WriteToStorage(List<Book> bookList)
		{
			if (ReferenceEquals(bookList, null)) throw new ArgumentNullException($"{nameof(bookList)} is invalid!");

			using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate)))
			{
				foreach (Book b in bookList)
				{
					writer.Write(b.Name);
					writer.Write(b.Author);
					writer.Write(b.Year);
					writer.Write(b.Pages);
				}
			}
		}
	}
}
