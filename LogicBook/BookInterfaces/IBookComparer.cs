using System;
namespace LogicBook
{
	public interface IBookComparer
	{
		int Compare(Book lhs, Book rhs); 
	}
}
