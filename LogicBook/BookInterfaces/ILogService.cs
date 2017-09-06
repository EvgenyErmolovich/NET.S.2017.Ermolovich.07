using System;
namespace LogicBook
{
	public interface ILogService
	{
		void Debug(DateTime time, string recordInfo, string record);
		void Info(DateTime time, string recordInfo, string record);
		void Warn(DateTime time, string recordInfo, string record);
		void Error(DateTime time, string recordInfo, string record);
		void Fatal(DateTime time, string recordInfo, string record);
	}
}
