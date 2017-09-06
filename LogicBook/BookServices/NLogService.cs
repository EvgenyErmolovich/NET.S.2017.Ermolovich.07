using System;
using NLog;

namespace LogicBook
{
	public class NLogService : ILogService
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();
		/// <summary>
		/// Write the specified time, recordInfo and record.
		/// </summary>
		/// <returns>The write.</returns>
		/// <param name="time">Time.</param>
		/// <param name="recordInfo">Record info.</param>
		/// <param name="record">Record.</param>
		public void Debug(DateTime time, string recordInfo, string record)
		{
			logger.Info("---");
			logger.Info(time);
			logger.Debug(recordInfo);
			logger.Debug(record);
			logger.Info("---");
		}
		/// <summary>
		/// Error the specified time, recordInfo and record.
		/// </summary>
		/// <returns>The error.</returns>
		/// <param name="time">Time.</param>
		/// <param name="recordInfo">Record info.</param>
		/// <param name="record">Record.</param>
		public void Error(DateTime time, string recordInfo, string record)
		{
			logger.Info("---");
			logger.Info(time);
			logger.Error(recordInfo);
			logger.Error(record);
			logger.Info("---");
		}
		/// <summary>
		/// Fatal the specified time, recordInfo and record.
		/// </summary>
		/// <returns>The fatal.</returns>
		/// <param name="time">Time.</param>
		/// <param name="recordInfo">Record info.</param>
		/// <param name="record">Record.</param>
		public void Fatal(DateTime time, string recordInfo, string record)
		{
			logger.Info("---");
			logger.Info(time);
			logger.Fatal(recordInfo);
			logger.Fatal(record);
			logger.Info("---");
		}
		/// <summary>
		/// Info the specified time, recordInfo and record.
		/// </summary>
		/// <returns>The info.</returns>
		/// <param name="time">Time.</param>
		/// <param name="recordInfo">Record info.</param>
		/// <param name="record">Record.</param>
		public void Info(DateTime time, string recordInfo, string record)
		{
			logger.Info("---");
			logger.Info(time);
			logger.Info(recordInfo);
			logger.Info(record);
			logger.Info("---");
		}
		/// <summary>
		/// Warn the specified time, recordInfo and record.
		/// </summary>
		/// <returns>The warn.</returns>
		/// <param name="time">Time.</param>
		/// <param name="recordInfo">Record info.</param>
		/// <param name="record">Record.</param>
		public void Warn(DateTime time, string recordInfo, string record)
		{
			logger.Info("---");
			logger.Info(time);
			logger.Warn(recordInfo);
			logger.Warn(record);
			logger.Info("---");

		}
	}
}
