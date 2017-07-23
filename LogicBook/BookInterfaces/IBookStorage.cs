using System;
using System.Collections.Generic;
namespace LogicBook
{
	public interface IBookStorage
	{
		IEnumerable<Book> ReadFromStorage();
		void WriteToStorage(IEnumerable<Book> bookList); 
	}
}
