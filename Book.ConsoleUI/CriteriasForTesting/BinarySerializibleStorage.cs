using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace LogicBook.ConsoleUI
{
	public class BinarySerializibleStorage: IBookStorage
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

		public BinarySerializibleStorage(string filename)
		{
			FileName = filename;
		}

		public IEnumerable<Book> ReadFromStorage()
		{
			if (!File.Exists(FileName)) throw new FileNotFoundException();
			using (FileStream stream = new FileStream(FileName, FileMode.Open))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				List<Book> list = (List<Book>)formatter.Deserialize(stream);

				return list;
			}
		}

		/// <summary>
		/// A method to save a list of books to binary file
		/// </summary>
		/// <param name="list">Coolection to save</param>
		public void WriteToStorage(IEnumerable<Book> list)
		{
			if (list == null)
				throw new ArgumentNullException();
			using (FileStream stream = new FileStream(FileName, FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, list);
			}
		}
	}
}
