using System.Diagnostics;
using System.Net;
using System.Threading;



namespace Threading
{
    public delegate void SumofNumberCallback(int sum);
    
    class Program
    {
        static object _lock = new object();
        public static void DisplaySumofNum(int sum)
        {
            Console.WriteLine($" the sum of two number is {sum}");
        }
        static void Main(string[] args)
        {

            /*

            var url = "https://engineering-ahmed.dafater.biz/server.py";

            HttpWebRequest? httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json, text/javascript, *//*; q=0.01";
            httpRequest.Headers["Accept-Language"] = "en-US,en;q=0.9,ar-EG;q=0.8,ar;q=0.7";
            httpRequest.Headers["Connection"] = "keep-alive";
            httpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            httpRequest.Headers["Cookie"] = "_hjSessionUser_2817410=eyJpZCI6IjhhMGRiZjA5LTkyMGEtNTFlMS04MTdlLWY0NTQxNjY3NmM0YSIsImNyZWF0ZWQiOjE2NjYyNzIzNTcyMzUsImV4aXN0aW5nIjp0cnVlfQ==; SL_G_WPT_TO=ar; _gat=1; _hjAbsoluteSessionInProgress=0; _hjSessionUser_2817410=eyJpZCI6IjhhMGRiZjA5LTkyMGEtNTFlMS04MTdlLWY0NTQxNjY3NmM0YSIsImNyZWF0ZWQiOjE2NjYyNzIzNTcyMzUsImV4aXN0aW5nIjp0cnVlfQ==; country=None; _hjIncludedInPageviewSample=1; _hjIncludedInSessionSample=1; SL_GWPT_Show_Hide_tmp=1; SL_wptGlobTipTmp=1; dafatererp-nextrecon=1674640442396; full_name=Administrator; sid=9e8a38c3a57ba04193235fbf3c56ef22480128ec6e8af807baacc92c; _ga=GA1.2.732084640.1674721362; _gid=GA1.2.1787973447.1674721362; _ga=GA1.2.732084640.1674721362; _gid=GA1.2.1787973447.1674721362; _hjSession_2817410=eyJpZCI6ImRmNzFkYjA4LTQwNWUtNDBlZS1hNWY1LTNlYTIzYWJmM2UzOCIsImNyZWF0ZWQiOjE2NzQ3MjQ2Nzg2MjIsImluU2FtcGxlIjpmYWxzZX0=; dafatererp-_zldp=MxMMJZZWagerH9S%2B9ymZBawKbWZblIYDfwwbKBTqWi%2BeGlrhMLd5uTa6qnCJYT03UWfBQUDgTVw%3D; dafatererp-_zldt=9879984f-7782-4367-ac6e-fad58fc2aaaf-0; dafatererp-_zldp=MxMMJZZWagefEQA1b6teVxx4301HIMiyf87InlgX43osCYV%2BLf%2FMhweajz3QF0wUUWfBQUDgTVw%3D; dafatererp-_zldt=585a42aa-b6be-4088-8e8e-1f7a6fabee62-2; SL_GWPT_Show_Hide_tmp=1; SL_G_WPT_TO=ar; SL_wptGlobTipTmp=1; _ga=GA1.2.732084640.1674721362; _gat=1; _gid=GA1.2.1787973447.1674721362; _hjAbsoluteSessionInProgress=0; _hjIncludedInPageviewSample=1; _hjIncludedInSessionSample=1; _hjSessionUser_2817410=eyJpZCI6IjhhMGRiZjA5LTkyMGEtNTFlMS04MTdlLWY0NTQxNjY3NmM0YSIsImNyZWF0ZWQiOjE2NjYyNzIzNTcyMzUsImV4aXN0aW5nIjp0cnVlfQ==; _hjSession_2817410=eyJpZCI6ImRmNzFkYjA4LTQwNWUtNDBlZS1hNWY1LTNlYTIzYWJmM2UzOCIsImNyZWF0ZWQiOjE2NzQ3MjQ2Nzg2MjIsImluU2FtcGxlIjpmYWxzZX0=; country=None; dafatererp-_zldp=MxMMJZZWagefEQA1b6teVxx4301HIMiyf87InlgX43osCYV%2BLf%2FMhweajz3QF0wUUWfBQUDgTVw%3D; dafatererp-_zldt=585a42aa-b6be-4088-8e8e-1f7a6fabee62-2; dafatererp-nextrecon=1674640442396; full_name=Administrator; sid=9e8a38c3a57ba04193235fbf3c56ef22480128ec6e8af807baacc92c";
            httpRequest.Headers["Origin"] = "https://engineering-ahmed.dafater.biz";
            httpRequest.Headers["Referer"] = "https://engineering-ahmed.dafater.biz/app.html";
            httpRequest.Headers["Sec-Fetch-Dest"] = "empty";
            httpRequest.Headers["Sec-Fetch-Mode"] = "cors";
            httpRequest.Headers["Sec-Fetch-Site"] = "same-origin";
            httpRequest.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
            httpRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
            httpRequest.Headers["sec-ch-ua-mobile"] = "?0";

            var data = "from_form=1&doctype=Purchase+Invoice&docname=BILL00001&params=%7B%7D&file_url=&filename=txt12.txt&filedata=dHR0dHR0dHR0&cmd=uploadfile&_type=POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);
            /*
             *  /// <summary>
        /// end user session by Marwa
        /// </summary>
        /// <returns>Logout </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public dynamic uploadFile(string filename, string fileData, string doctype, string docname)
        {
            dynamic result = null;
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "from_form","1"},
                    { "doctype", doctype},
                    { "docname", docname},
                    { "params","{}"},
                    { "file_url",""},
                    { "filename", filename},
                    { "filedata",fileData},
                    { "cmd","uploadfile"},
                    { "_type","POST"},


                };
                result = Session.Http.DoPostFile(Session.Url, parameters);

                ClientHelpers.CheckForException(result);
            }
            catch (DocumentNotFoundException)
            {


            }
            return ClientHelpers.DafaterToDynamicObject(result);

        }
            /*
             * /// <summary>
        /// Post multiple documents
        /// </summary>
        /// <remarks>
        /// 
        /// 
        /// </remarks>
        /// <param name="UploadFileDTO">The type of the File to be Uploaded</param>
        /// <response code="200">Documents are deleted succesfully</response>
        /// <response code="404">Some document is not found</response>
        [HttpPost("uploadFile/{docType}/{docName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UploadFile(string docType,string docName, [FromForm] UploadFileDTO fileArg)
        {
            try
            {
                var session = SessionWebRequest();
                _documentClient = new DocumentClient(session);
                if(fileArg.file == null)
                {
                    return StatusCode(422, "Attached File Not Found");
                }
                using (var ms = new MemoryStream())
                {
                    fileArg.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string fileBase64String = Convert.ToBase64String(fileBytes);
                    _documentClient.uploadFile(fileArg.file.FileName, fileBase64String, docType, docName);
                }

            }
            catch (Exception exception)
            {
                Logger.LogCritical(exception, $"Exception while deleting");

                var exceptionType = exception.GetType();
                if (exceptionType == typeof(SecurityException) ||
                    exceptionType == typeof(SubscriptionException)) return Unauthorized();

                if (exceptionType == typeof(DocumentNotFoundException)) return NotFound(Regex.Unescape(exception.Message.Replace(@"\\", @"\")));

                if (exceptionType == typeof(InvalidOperationException) ||
                    exceptionType == typeof(ValidationException) ||
                    exceptionType == typeof(InvalidDocumentStatusTransitionException) ||
                    exceptionType == typeof(RelatedDocumentExistException)) return BadRequest(Regex.Unescape(exception.Message.Replace(@"\\", @"\")));

                return StatusCode(500, Regex.Unescape(exception.Message.Replace(@"\\", @"\")));
            }
            return Ok(new { status = true, message = "Student Posted Successfully" });
        }
            /*
            for (int i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithWorkItem();
            }
            */
            // Testing the boxing and unboxing 
            /*
                 A a = new A();
                 a.TestMethod();
                 A a1 = new B();
                 a1.TestMethod();
                 A b = new B();
                 A b2 =(A)b;
                 b2.TestMethod();
                  A b3 = new B();
                 B b1 = (B)b3;
                 b1.TestMethod();
                 int x = 10;
                 object y = x;


                 Console.WriteLine("this is v value " + x);
                 Console.WriteLine("this is y value " +y);

                 y = 100;

                 Console.WriteLine("this is v value " + x);
                 Console.WriteLine("this is y value " + y);

                 try
                 {
                     Console.WriteLine((short)y);

                 }catch(Exception e)
                 {
                     Console.WriteLine(e.ToString());
                 }
                 int j = (int)y;
                 Console.WriteLine("this is j value " + j);
                 Console.ReadLine();
            */
            //int max = 10;
            //SumofNumberCallback _sumofNumberCallback = new SumofNumberCallback(DisplaySumofNum);
            //NumberHelper numberHelper = new NumberHelper(max, _sumofNumberCallback);

            //ThreadStart threadStart =new ThreadStart(numberHelper.sum);

            //Thread thread = new Thread(threadStart);

            //thread.Start();
            /*
            Thread threadWrite = new Thread(() => Write("Write"));
            Thread threadRead = new Thread(() => Read());

            threadWrite.Start();
            threadRead.Start();

            threadWrite.Join();

            threadRead.Join();

            */
            /*
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("stop watch is elapsed "+ stopwatch.ElapsedTicks.ToString());

            stopwatch.Restart();
            MethodWithWorkItem();
            stopwatch.Stop();
            Console.WriteLine("stop watch is elapsed " + stopwatch.ElapsedTicks.ToString());
            */
            /*
            Console.WriteLine($"Main thread Started");
            Task<string> task = Task.Run(() => { return Method2(5); }).ContinueWith((info) => { return $"the sum of value is {info.Result}"; });

            Console.WriteLine($"Main thread Ended");
            task.Wait();
            string x = task.Result;
            Console.WriteLine(x);
            Console.WriteLine($"Main thread Ended" + x);
            task.ContinueWith((res) =>
            {
                Console.WriteLine($"{res.IsFaulted} {res.IsCanceled} {res.IsCompleted} {res.Exception?.Message}");
            });
            task.ContinueWith((res) =>
            {
                Console.WriteLine($"Task Completed");
            },TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((res) =>
            {
                Console.WriteLine($"Task Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            Console.ReadKey();
            */
            /*
            int workers, ports;

            Console.WriteLine("Hello, World!");
            // Get maximum number of threads  
            ThreadPool.GetMaxThreads(out workers, out ports);
            Console.WriteLine($"Maximum worker threads: {workers} ");
            Console.WriteLine($"Maximum completion port threads: {ports}");
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";
            Console.WriteLine($"My current Thread -  {Thread.CurrentThread.Name}");

            Thread thread1 = new Thread(Method1) { Name = "Thread1" };

            Console.WriteLine("Method 1 execution is completed");

            Thread thread2 = new Thread(Method2) { Name = "Thread2" };
            Console.WriteLine("Method 2 execution is completed");

            Thread thread3 = new Thread(Method3) { Name = "Thread3" };
            Console.WriteLine("Method 3 execution is completed");


            ThreadPool.QueueUserWorkItem(Method1, "hello from thread 1 ");//.Start("hello from thread 1 ");
            thread2.Start();
            thread3.Start();

            // Get maximum number of threads  
            ThreadPool.GetMaxThreads(out workers, out ports);
            Console.WriteLine($"Maximum worker threads: {workers} ");
            Console.WriteLine($"Maximum completion port threads: {ports}");
            */
            /* create parallel prigramming
            int length = 10;

            Console.WriteLine(" Program is started");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"here the iteration of for {i} Thread {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(10);
            }
            sw.Stop();

            Console.WriteLine($"the time is taken from for is {sw.ElapsedMilliseconds}");
            ParallelOptions _option = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 4,
            };
            sw.Restart();
            Parallel.For(0,length, _option, (i,breakCount) =>
            {
                if(i < length - 5)
                {
                    breakCount.Break();
                }
                Console.WriteLine($"here from the parallet {i} Thread {Thread.CurrentThread.ManagedThreadId}");
            });
            sw.Stop();
            Console.WriteLine($"the time is taken from for is {sw.ElapsedMilliseconds}");
            */
            Console.WriteLine("Main method started");
            var numbers = Enumerable.Range(0,100);

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var source = from num in numbers.AsParallel()
                         where num % 5  == 0
                         select num;

            sw.Stop();
            Console.WriteLine($"{source.Count()} time taken is {sw.ElapsedMilliseconds}");

            sw.Restart();
            var nums = from num in numbers
                         where num % 5 == 0
                         select num;

            sw.Stop();
            Console.WriteLine($"{nums.Count()} time taken is {sw.ElapsedMilliseconds}");


        }
        static void MethodWithThread()
        {
            for(int i= 0; i < 10; i++)
            {
                Thread thread = new Thread(Method1);
            }
        }
        static void MethodWithWorkItem()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Method1));
            }
        }
        static void Write(object o)
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 10; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine($"Write function start {i} {o}");
                Console.WriteLine($"Write function end {i}");
                Monitor.Wait(_lock);
            }
        }
        public static void Read()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 10; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine($"Read function start {i}");
                Console.WriteLine($"Read function end {i}");
                Monitor.Wait(_lock);
            }
        }
        static void Method1(object data)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                //Console.WriteLine($"Method 1 invoked {i}");
            }

        }

        static int Method2(int v)
        {
            int sum = 0;
            for (int i = 0; i < v; i++)
            {
                sum += i;
                //Console.WriteLine($"Method 2 invoked {i}");
                //Thread.Sleep(1000);
                //Console.WriteLine("execution code completed");
            }
            return sum;

        }

        static void Method3()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method 3 invoked {i}");
            }

        }

    }

    class A
    {
        public virtual void TestMethod()
        {
            Console.WriteLine("I'm From A");

        }
    }
    class B : A
    {
        public override void TestMethod()
        {
            Console.WriteLine("I'm From B");

        }
    }

    class NumberHelper
    {
        SumofNumberCallback _callBack;
        int _num;
        public NumberHelper(int num, SumofNumberCallback callBack)
        {
            _num = num;
            _callBack = callBack;

        }
        public void sum()
        {
            int sum = 0;
            for (int i = 0; i < _num; i++)
            {
                sum += i;
            }
            if(_callBack != null)
                _callBack.Invoke(sum);
        }
    }
}







