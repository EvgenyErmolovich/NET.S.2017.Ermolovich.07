using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace LogicBook.ConsoleUI
{
	public class XMLSerializibleStorage: IBookStorage
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

		public XMLSerializibleStorage(string filename)
		{
			FileName = filename;
		}

		public IEnumerable<Book> ReadFromStorage()
		{
			if (!File.Exists(FileName)) throw new FileNotFoundException();
			using (FileStream stream = new FileStream(FileName, FileMode.Open))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
				List<Book> bookList = (List<Book>)serializer.Deserialize(stream);
				return bookList;
			}	
		}		
		public void WriteToStorage(IEnumerable<Book> list)
		{
			if (list == null)
				throw new ArgumentNullException();
			using (FileStream stream = new FileStream(FileName, FileMode.Create))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
				serializer.Serialize(stream, list);
			}
		}
	}
}
