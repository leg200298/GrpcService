using B2E.Core.Model.FORMAL;
using B2E.Job;
using Newtonsoft.Json;
using NLog;
using Red.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static B2E.Job.OCRJob;

namespace TestFramework
{
    class Program
    {
        static Logger log = LogManager.GetCurrentClassLogger();
        static Mutex mutex = new System.Threading.Mutex();
        static bool isLock = false;
        private static async Task Main(string[] args)
        {

            #region 測試Concurrent

            //ConcurrentBagWithPallel();
            //Console.ReadKey();

            #endregion

            #region 測試Task

            //Console.WriteLine("Application executing on thread {0}",
            //       Thread.CurrentThread.ManagedThreadId);
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

            #region 測試Mutex
            //var test = GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            //Console.WriteLine(test);

            //byte[] imageData = null;
            //mutex.WaitOne();
            //mutex.WaitOne();
            //mutex.ReleaseMutex();
            //mutex.ReleaseMutex();
            //int count = 0;
            //while (true)
            //{
            //    count = count + 1;
            //    Thread.Sleep(1000);

            //    Task.Run(() =>
            //    {
            //        var handle = false;
            //        try
            //        {
            //            Console.WriteLine($"Input Count  {count} : {Thread.CurrentThread.ManagedThreadId}");

            //            if (handle = mutex.WaitOne(1000))
            //            {
            //                Console.WriteLine($"Output Count  {count} : {Thread.CurrentThread.ManagedThreadId}");
            //                Thread.Sleep(5000);
            //                Console.WriteLine($"Thread Sleep Count  {count} : {Thread.CurrentThread.ManagedThreadId}");                          
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //        }
            //        finally
            //        {
            //            if(handle)
            //            {
            //                mutex.ReleaseMutex();
            //            }                       
            //        }
            //    });
            //}

            #endregion

            #region 測試NAS連線
            //imageData = File.ReadAllBytes(@"C:\Users\yuchia.yang\Desktop\根據參考有使用到的B2C_Nas\無此檔案.txt");
            //testmodel testmodel = new testmodel { Test = JsonTest.Test };
            // Console.WriteLine(testmodel.Test.ToString());
            // var test2 = JsonConvert.SerializeObject(testmodel);
            // Console.WriteLine(test2);

            // var test3 = JsonConvert.DeserializeObject<testmodel>(test2);
            //Console.WriteLine("test");

            //int number = 0;
            //while (number <= 10000)
            //{
            //    Console.WriteLine($"Run count : {number} , time : {DateTime.Now}");
            //    try
            //    {
            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");


            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\NXimg", @"etzone\web-admin", "Aa123456");
            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");
            //        UNCResource.Connection(@"\\dev-nas01.etzone.net\BBCONT", @"etzone\web-admin", "Aa123456");

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //    number = number + 1;
            //} 
            #endregion

            #region CDN
            //List<string> tobeReplace = new List<string> { @"\\ns3000.etmall.front\nximg",
            //    "http://media.etmall.com.tw/NXimg",
            //    "https://media.etmall.com.tw/NXimg",
            //    "http://media.u-mall.com.tw/NXimg",
            //    "https://media.u-mall.com.tw/NXimg" };
            //tobeReplace.Add(@"\\132080P-MEDIA01\Nximg");
            //tobeReplace.Add(@"\\132081P-MEDIA02\Nximg");

            //List<string> filepaths = new List<string>();
            //filepaths.Add(@"\\ns3000.etmall.front\nximg\002418\2418164\2418164-1_XXXL.jpg");
            //filepaths.Add(@"https://media.etmall.com.tw/NXimg/002418/2418164/2418164-1_XXXL.jpg");
            //filepaths.Add(@"\\132080P-MEDIA01\Nximg\002418\2418164\2418164-1_XXXL.jpg");

            //var nasPaths = new string[] { @"\\ns3000.etmall.front\nximg", @"\\132080P-MEDIA01\Nximg", @"\\132081P-MEDIA02\Nximg" };

            //var t = filepaths[0];
            //var t2 = tobeReplace[0];
            //var t3 = tobeReplace.Exists(k => t.StartsWith(k));
            //var t4 = Array.Exists(nasPaths, p => t.StartsWith(p));
            //Console.WriteLine(t.Contains(t2));

            //var imgUrls = new List<string>();
            //var imgUrlsLowCase = new List<string>();

            //filepaths.ForEach(f =>
            //{
            //    var replacePath = tobeReplace.Where(c => f.Contains(c)).FirstOrDefault();
            //    if (!string.IsNullOrEmpty(replacePath))
            //    {
            //        var path = f.Replace(replacePath, @"http://origin-media.etmall.com.tw/NXimg").Replace(@"\", @"/");
            //        imgUrls.Add(path);
            //        imgUrlsLowCase.Add(path.ToLower());
            //    }
            //});

            //imgUrls.AddRange(imgUrlsLowCase);
            //imgUrls = imgUrls.Distinct().ToList();
            //Console.WriteLine(JsonConvert.SerializeObject(imgUrls));
            #endregion

            #region 抓類別名稱
            //var data = System.Reflection.MethodBase.GetCurrentMethod();

            //string showString = "";
            ////取得當前方法類別命名空間名稱
            //showString += "Namespace:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";
            ////取得當前類別名稱
            //showString += "class Name:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";
            ////取得當前所使用的方法
            //showString += "Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n";

            //Console.WriteLine(showString);

            //MethodInfo methodInfo = new MethodInfo();
            //Console.WriteLine(MethodInfo.GetCurrentMethodInfo());
            //String strStackTrace = TestFramework.MethodInfo.GetParentInfo();
            //Console.WriteLine(strStackTrace); 
            #endregion

            #region 測試b2e.Job MoveVideoJob & VideoInfromtion 9527
            //MoveVideoJob moveVideoJob = new MoveVideoJob();
            //OCRJob oCRJob = new OCRJob();
            //VideoInfromtion videoInfromtion = new VideoInfromtion();
            //videoInfromtion.FileName = "helloTestVideo.mp4";
            //videoInfromtion.VideoPath = @"helloTestVideo.mp4";
            //videoInfromtion.CoverPath = @"helloTestVideo.mp4";

            //IV_Data iV_Data = new IV_Data();
            //iV_Data.create_by = 9527;
            //iV_Data.id = 9527;
            //iV_Data.cover = @"helloTestVideo.mp4";
            //iV_Data.url = @"helloTestVideo.mp4";

            //var test = moveVideoJob.TryMoveVideoData(iV_Data);
            //var test2 = oCRJob.TryMoveVideoData(videoInfromtion, false); 
            #endregion

            #region File測試
            if (File.Exists(@"\\SCM\xcopyExcludex.txt"))
            {
                File.Delete(@"\\SCM\xcopyExcludex.txt");
            }

            //var picBytes = File.ReadAllBytes("yuchia_yang.png");
            //string strSavePicForder = string.Format("/" + "B2BUserFiles2" + "/Product/TemporarilyPicture/{0}/", DateTime.Now.Date.ToString("yyyyMMdd")); //目的存檔路徑
            //Console.WriteLine(HttpContext.Current.Server.MapPath(strSavePicForder));
            //File.Copy("yuchia_yang.png", "yuchia_yang.png2", false);
            //Check if the pic Width and Height not equal
            //Image source ;
            //using (MemoryStream memstr = new MemoryStream(picBytes))
            //{
            //    source = Image.FromStream(memstr);
            //}

            //Console.WriteLine($"{source.Width}  {source.Height}"); 
            #endregion

            //int int100 = 100;

            //long int32100 = int100;

            //log.Info(new Exception("Hello"), "Test");
            //Console.WriteLine(Directory.Exists(string.Empty))
            using (Bitmap test = new Bitmap("yuchia_yang.jpg"))
            {

                var requestw = test.Size.Width;
                var requesth = test.Size.Height;

                var _jpegCodec = ImageCodecInfo.GetImageEncoders().Where(codec => codec.MimeType == "image/jpeg").FirstOrDefault();
                var _encoderParams = new EncoderParameters(1);
                _encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);

                int largestDimension = Math.Max(2000,2000);
                Size squareSize = new Size(largestDimension, largestDimension);

                using (Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(squareImage))
                    {
                        graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(test, 0, 0, squareSize.Width, squareSize.Height);
                        squareImage.Save("test3", _jpegCodec, _encoderParams);
                    }
                }
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

    public class MethodInfo
    {
        /// <summary>
        /// 取得 目前正在執行的 Function Info 資訊
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentMethodInfo()
        {
            string showString = "";
            //取得當前方法類別命名空間名稱
            showString += "Namespace:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";
            //取得當前類別名稱
            showString += "class Name:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";
            //取得當前所使用的方法
            showString += "Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n";

            return showString;
        }

        /// <summary>
        /// 取得父類別的相關資訊(共用的Functiond可用)
        /// </summary>
        /// <returns></returns>
        public static String GetParentInfo()
        {
            String showString = "";
            StackTrace ss = new StackTrace(true);
            //取得呼叫當前方法之上一層類別(GetFrame(1))的屬性
            MethodBase mb = ss.GetFrame(1).GetMethod();

            //取得呼叫當前方法之上一層類別(父方)的命名空間名稱
            showString += mb.DeclaringType.Namespace + "\n";

            //取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
            showString += mb.DeclaringType.Name + "\n";

            //取得呼叫當前方法之上一層類別(父方)的Full class Name
            showString += mb.DeclaringType.FullName + "\n";

            //取得呼叫當前方法之上一層類別(父方)的Function Name
            showString += mb.Name + "\n";

            return showString;
        }
    }
    public class testmodel
    {
        public JsonTest Test { get; set; }
        public string Test2 { get; set; } = "default Value";
    }

    public class test
    {
        public int t1 { get; set; } = 3;
        public string t2 { get; set; } = "2 ";

        public test2 c2 { get; set; } = new test2();
    }
    public class test2
    {
        public int t3 { get; set; } = 1;
    }
}
