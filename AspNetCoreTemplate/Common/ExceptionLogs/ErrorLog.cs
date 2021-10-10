using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace AspNetCoreTemplate.Common.ExceptionLogs
{
    public class ErrorLog
    {
        private readonly IConfiguration _configuration;
        
        public ErrorLog(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool WriteErrorLog(string logMessage)
        {
            bool status = false;
            string logDirectory = _configuration["LogDirectory"].ToString();

            DateTime currentDateTime = DateTime.Now;
            string currentDateTimeString = currentDateTime.ToString();
            CheckCreateLogDirectory(logDirectory);
            string logLine = BuildLogLine(currentDateTime, logMessage);
            logDirectory = (logDirectory + LogFileName(DateTime.Now) + ".txt");

            lock (typeof(ErrorLog))
            {
                StreamWriter oStreamWriter = null;
                try
                {
                    oStreamWriter = new StreamWriter(logDirectory, true);
                    oStreamWriter.WriteLine(logLine);
                    status = true;
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    if (oStreamWriter != null)
                    {
                        oStreamWriter.Close();
                    }
                }
            }
            return status;
        }


        private bool CheckCreateLogDirectory(string logPath)
        {
            bool loggingDirectoryExists = false;
            DirectoryInfo oDirectoryInfo = new DirectoryInfo(logPath);
            if (oDirectoryInfo.Exists)
            {
                loggingDirectoryExists = true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(logPath);
                    loggingDirectoryExists = true;
                }
                catch
                {
                    // Logging failure
                }
            }
            return loggingDirectoryExists;
        }


        private string BuildLogLine(DateTime currentDateTime, string logMessage)
        {
            StringBuilder loglineStringBuilder = new StringBuilder();
            loglineStringBuilder.Append(LogFileEntryDateTime(currentDateTime));
            loglineStringBuilder.Append(" \t");
            loglineStringBuilder.Append(logMessage);
            return loglineStringBuilder.ToString();
        }


        public string LogFileEntryDateTime(DateTime currentDateTime)
        {
            return currentDateTime.ToString("dd-MM-yyyy HH:mm:ss");
        }


        private string LogFileName(DateTime currentDateTime)
        {
            return currentDateTime.ToString("dd_MM_yyyy");
        }
    }
}
