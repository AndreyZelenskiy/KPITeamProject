using System;
using System.IO;

namespace Server
{
    static class Log
    {
        private static string _pathToFile;
        private static FileStream _connection;

        private static bool flag;

        static Log()
        {
            flag = true;
            _pathToFile = @"C:\Users\Андрей\Documents\KPITeamProject\ServerLog.log";
            try
            {
                _connection = File.Open(_pathToFile, FileMode.OpenOrCreate);
            }
            catch (IOException ex)
            {
                flag = false;
                Console.WriteLine("Error create log stream to file");
            }

        }

        public static void Write(string inputMessage, bool status)
        {
            if (flag)
            {
                string message = String.Format("[{0}][{1}][{2}]", DateTime.Now, inputMessage, status);
                message += @"\n";

                byte[] array = System.Text.Encoding.ASCII.GetBytes(message);

                try
                {
                    _connection.Write(array, 0, array.Length);
                }
                catch (IOException ex)
                {
                    flag = false;
                    Console.WriteLine("Failed to write log", ex.Message);
                }
            }
            else { }
        }
    }
}