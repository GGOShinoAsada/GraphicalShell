using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using System.IO;

namespace GraphicalShell.Resourses
{
    static class WorkWithCMD
    {
        public static int TimeOut { get; set; } = int.MaxValue;
        /// <summary>
        /// доступ к пути универсальный для проекта -
        /// </summary>
        /// <returns></returns>
        private static string file()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace(@"\bin\Debug", @"\command files\");
            return path;
        }
        /// <summary>
        /// метод, открывающий BAT файл и выводящий его путь
        /// </summary>
        public static string OpenFile()
        {
            string path = "";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "bat file (*.bat)|*.bat|All files (*.*)|*.*";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
                
                    
                
            }
            return path;
        }



        //public static Task<string> StartProcessAsync(string filename, string args = "")
        //{

        //    //await Task.Delay(100).ConfigureAwait(false);
        //    Task<string> task1 = Task.Factory.StartNew(() => StartProcess(filename, args));
        //    Task<string> task2 = Task.Factory.StartNew(() => StartProcess(filename, args));
        //    Task.WaitAll(task1, task2);
        //    return task1;

        //}
        public static Task<string> ExecuteCommandCMDAsync(string filename, string arguments)
        {
           // await Task.Delay(100).ConfigureAwait(false);
            Task<string> task1 = Task.Factory.StartNew(() => ExecuteCommandCMD(filename, arguments));
            // Task<string> task2 = Task.Factory.StartNew(() => ExecuteCommandCMD(filename, arguments));
            task1.Wait();
            //Task.WaitAll(task1, task2);
            // Task<string> tr = new 
            return task1;
        }
        public static string ExecuteCommandCMD(string filename, string args = "")
        {
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = filename,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardErrorEncoding = Encoding.GetEncoding(866),
                    StandardOutputEncoding = Encoding.GetEncoding(866),
                    CreateNoWindow = true
                    
                }


            };
            p.Start();

            string cv_error = null; string cv_out = null;

            //Task<string> OutputTask = Task.Run(async ()=>cv_out = await p.StandardOutput.ReadToEndAsync());
            //Task<string> ErrorsTask = Task.Run(async () => cv_out = await p.StandardError.ReadToEndAsync());
            //Thread OutpuThread = new Thread();

            Thread OutputThread = new Thread(()=>cv_out=p.StandardOutput.ReadToEnd());

            Thread ErrorsThread = new Thread(()=> cv_error = p.StandardError.ReadToEnd());
            //Thread ErrorsThread = new Thread(async () => { cv_error = await p.StandardError.ReadToEndAsync(); });
            OutputThread.Start();
            ErrorsThread.Start();
            OutputThread.Join();
            ErrorsThread.Join();

            p.WaitForExit(TimeOut);



            return cv_out+cv_error;
           
        }

        //static async Task<string> ReadOutputThreadAsync(Process p)
        //{
        //    string data = "";
        //    data =  await p.StandardOutput.ReadToEndAsync();
        //    return data;

        //}
        //static async Task<string> ReadErrorThreadAsync(Process p)
        //{
        //    string data = "";
        //    data = await p.StandardError.ReadToEndAsync();
        //    return data;
        //}


        /// <summary>
        /// чтение BAT файла
        /// </summary>
        /// <param name="path"></param>
        public static async Task<string> GetStartAsync(string path, int n=0)
        {
            await Task.Delay(100).ConfigureAwait(false);
            string finoutput = "";
            try
            {
                var process = new Process();
                var startinfo = new ProcessStartInfo(path);
                startinfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                startinfo.RedirectStandardOutput = true;
                startinfo.UseShellExecute = false;
                startinfo.CreateNoWindow = true;
                process.StartInfo = startinfo;
             
                process.Start();
               // process.OutputDataReceived += PrOutput(process);

               
                //process.BeginOutputReadLine();

                process.WaitForExit(TimeOut);
                switch (n)
                {
                    case 0:
                        finoutput = await PrOutput(process);
                        break;
                    case 2:
                        finoutput = await PrError(process);
                        break;
                }
                return finoutput;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        static async Task<string> PrError(Process process)
        {
            string errors = "";

            while (!process.StandardError.EndOfStream)
            {
                string data = await process.StandardError.ReadLineAsync()+"\n";
              //  data=data.Replace(' ', '#');
                errors += data;
            }
            return errors;
        }
        static async Task<string> PrOutput(Process process)
        {
            string output = "";
            while (!process.StandardOutput.EndOfStream)
            {
                string data = await process.StandardOutput.ReadLineAsync()+"\n";
               // data = data.Replace(' ', '#');
                
                output += data;
            }
            return output;
        }

        /// <summary>
        /// печать событий на консоль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void Print(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                Console.WriteLine(args.Data);
            }
        }
        //private static Task<string> PrintAsync(object sender, DataReceivedEventArgs args)
        //{
            
        //}
        /// <summary>
        /// универсальный метод вывода на консоль принимает переменную и аргументы
        /// </summary>
        /// <param name="cmdpath"></param>
        /// <param name="args"></param>
        public static void ExecuteCommand(string cmdpath, string args)
        {

            try
            {
                var processinfo = new ProcessStartInfo(cmdpath, args);
                processinfo.CreateNoWindow = true;
                processinfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                processinfo.UseShellExecute = false;
                processinfo.RedirectStandardOutput = true;
                processinfo.RedirectStandardError = true;
                var process = Process.Start(processinfo);
                process.OutputDataReceived += Print;
                process.BeginOutputReadLine();
                process.ErrorDataReceived += Print;
                process.BeginErrorReadLine();
                //get output
                PrintConsole(process);

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

        }
        private static void PrintConsole(Process process)
        {
            string output = process.StandardOutput.ReadToEnd();
            foreach (string t in output.Split('\n'))
            {
                Console.WriteLine(t);
            }
        }
    }
}
