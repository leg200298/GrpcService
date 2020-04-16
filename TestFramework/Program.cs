using Newtonsoft.Json;
using Red.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFramework
{
    class Program
    {
        static Mutex mutex = new System.Threading.Mutex();
        static bool isLock = false;
        private static async Task Main(string[] args)
        {
            #region 測試Concurrent

            //ConcurrentBagWithPallel();
            //Console.ReadKey();

            #endregion

            #region 測試Task

            Console.WriteLine("Application executing on thread {0}",
                   Thread.CurrentThread.ManagedThreadId);
            //var asyncTask =  Task.Run(() => {
            //    Console.WriteLine("Task {0} (asyncTask) executing on Thread {1}",
            //                      Task.CurrentId,
            //                      Thread.CurrentThread.ManagedThreadId);
            //    long sum = 0;
            //    for (int ctr = 1; ctr <= 1000000; ctr++)
            //        sum += ctr;
            //    return sum;
            //});

            //var syncTask = new Task<long>(() =>
            //{
            //    Console.WriteLine("Task {0} (syncTask) executing on Thread {1}",
            //                       Task.CurrentId,
            //                       Thread.CurrentThread.ManagedThreadId);
            //    long sum = 0;
            //    for (int ctr = 1; ctr <= 1000000; ctr++)
            //        sum += ctr;
            //    return sum;
            //});
            //syncTask.RunSynchronously();


            // Console.WriteLine("Task {0} returned {1:N0}", syncTask.Id, syncTask.Result);
            //Console.WriteLine("Task 1 returned {0:N0}", asyncTask.Id, asyncTask.Result);

            #endregion

            //var test = GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            //Console.WriteLine(test);

            byte[] imageData = null;
            //mutex.WaitOne();
            //mutex.WaitOne();
            //mutex.ReleaseMutex();
            //mutex.ReleaseMutex();
            int count = 0;
            while (true)
            {
                count = count + 1;
                Thread.Sleep(1000);

                Task.Run(() =>
                {
                    var handle = false;
                    try
                    {
                        Console.WriteLine($"Input Count  {count} : {Thread.CurrentThread.ManagedThreadId}");

                        if (handle = mutex.WaitOne(1000))
                        {
                            Console.WriteLine($"Output Count  {count} : {Thread.CurrentThread.ManagedThreadId}");
                            Thread.Sleep(5000);
                            Console.WriteLine($"Thread Sleep Count  {count} : {Thread.CurrentThread.ManagedThreadId}");                          
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        if(handle)
                        {
                            mutex.ReleaseMutex();
                        }                       
                    }
                });


            }



            //imageData = File.ReadAllBytes(@"C:\Users\yuchia.yang\Desktop\根據參考有使用到的B2C_Nas\無此檔案.txt");
            //testmodel testmodel = new testmodel { Test = JsonTest.Test };
            // Console.WriteLine(testmodel.Test.ToString());
            // var test2 = JsonConvert.SerializeObject(testmodel);
            // Console.WriteLine(test2);

            // var test3 = JsonConvert.DeserializeObject<testmodel>(test2);
            Console.WriteLine("test");

            int number = 0;
            while (number <= 10000)
            {
                Console.WriteLine($"Run count : {number} , time : {DateTime.Now}");
                try
                {
                    UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
                    UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");


                    UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
                    UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
                    UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");
                    UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                number = number + 1;
            }

            Console.ReadKey();
        }

        public static async Task<string> Test()
        {
            var str = "test";
            Console.WriteLine("Task {0} (Task) executing on Thread {1}",
                   Task.CurrentId,
                   Thread.CurrentThread.ManagedThreadId);
            return str;
        }
        public static async Task<string> Test2()
        {
            var t = await Task.Run(() =>
              {
                  Console.WriteLine("Task {0} Test2 executing on Thread {1}",
                  Task.CurrentId,
                   Thread.CurrentThread.ManagedThreadId);
                  Thread.Sleep(5000);
                  return "test";
              });
            Console.WriteLine(t);
            return t;
        }
        public static void ConcurrentBagWithPallel()
        {
            ConcurrentBag<int> list = new ConcurrentBag<int>();
            Parallel.For(0, 10000, item =>
            {
                list.Add(item);
            });
            Console.WriteLine("ConcurrentBag's count is {0}", list.Count());
            int n = 0;
            foreach (int i in list)
            {
                if (n > 10)

                    break;
                n++;
                Console.WriteLine("Item[{0}] = {1}", n, i);
            }
            Console.WriteLine("ConcurrentBag's max item is {0}", list.Max());
        }
        static async Task<int> GetRemoteData()
        {
            int res = 0;
            var t = await Task.Run(() =>
             {
                 //假裝執行某個耗時程序後取得結果
                 Thread.Sleep(1000);
                 res = 32767;
                 return res;
             });
            return t;
        }

    }
    public class testmodel
    {
        public JsonTest Test { get; set; }
        public string Test2 { get; set; } = "default Value";
    }
}
