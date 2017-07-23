using System;
namespace LogicBook
{
	public interface ILogService
	{
		void Debug(DateTime time, string message);
		void Info(DateTime time, string message);
		void Warn(DateTime time, string message);
		void Error(DateTime time, string message);
		void Fatal(DateTime time, string message);
	}
}
