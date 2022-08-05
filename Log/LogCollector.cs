using System;
using System.IO;
using System.Threading.Tasks;

namespace ChanWooLib.LogCollector
//public static class log_collector
{


    public static class LogCollector
    {
        static LogCollector() { }



        public static void LogWriterFree(string _msg,string _path="", string _log_file_name = "syslog")
        {
            try
            {

                //   1. 바코드 프로그램램 폴더\Logs\현재년도\현재년도-월\  의 형태로 폴더를 생성하기.
                var dir = string.IsNullOrEmpty(_path)? AppDomain.CurrentDomain.BaseDirectory+ "\\logs\\" + String.Format("{0:yyyy}", DateTime.Now) + "\\" + String.Format("{0:yyyy-MM}", DateTime.Now) : _path;
                var chk = new DirectoryInfo(dir);

                //   2. 폴더가 이미 생성되었는지의 여부를 검사하여 없다면 해당 경로의 폴더를 생성해주기.
                if (!chk.Exists)
                    chk.Create();
                //   3. 년도-월-일의 형태로 파일을 생성하여 로그를 기록함.


                    using (var log_writer = new System.IO.StreamWriter(dir + string.Format("\\{0}_{1}.log", _log_file_name, String.Format("{0:yyyy-MM-dd}", DateTime.Now)), true))
                    {
                        log_writer.WriteLine("Date : " + System.DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss"));
                        log_writer.WriteLine(string.Empty);
                        log_writer.WriteLine(_msg);
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                    }
            }
            catch (Exception eeee) { }
        }


        public static void LogWriter1(string _msg, string _log_file_name = "syslog")
        {
            try
            {
                //   1. 바코드 프로그램램 폴더\Logs\현재년도\현재년도-월\  의 형태로 폴더를 생성하기.
                var dir = "d:\\logs\\" + String.Format("{0:yyyy}", DateTime.Now) + "\\" + String.Format("{0:yyyy-MM}", DateTime.Now);
                var chk = new DirectoryInfo(dir);

                //   2. 폴더가 이미 생성되었는지의 여부를 검사하여 없다면 해당 경로의 폴더를 생성해주기.
                if (!chk.Exists)
                    chk.Create();
                //   3. 년도-월-일의 형태로 파일을 생성하여 로그를 기록함.


                    using (var log_writer = new System.IO.StreamWriter(dir + string.Format("\\{0}_{1}.log", _log_file_name, String.Format("{0:yyyy-MM-dd}", DateTime.Now)), true))
                    {
                        log_writer.WriteLine("Date : " + System.DateTime.Now);
                        log_writer.WriteLine(string.Empty);
                        log_writer.WriteLine(_msg);
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                        log_writer.WriteLine(string.Empty);//칸비우기 기능
                    }

            }
            catch (Exception eeee) { }
        }


    }
}
