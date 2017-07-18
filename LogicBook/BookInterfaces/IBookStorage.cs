using System;
using System.Collections.Generic;
namespace LogicBook
{
	public interface IBookStorage
	{
		List<Book> ReadFromStorage();
		void WriteToStorage(List<Book> bookList); 
	}
}
