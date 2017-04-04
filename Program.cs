using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(int hours, WorkType workType);

    //new custom delegate for Lambda
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer{City = "Phoenix",FirstName="John",LastName = "Doe",ID=1 },
                new Customer{City = "Phoenix",FirstName="Jane",LastName = "Doe",ID=500 },
                new Customer{City = "Seattle",FirstName="Suki",LastName = "Pizzoro",ID=3 },
                new Customer{City = "New York City",FirstName="Michelle",LastName = "Smith",ID=4 }
            };

            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach(var cust in phxCusts)
            {
                Console.WriteLine(cust.City);
            }

            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(2, 3,addDel);

            //Func<t,TResult> example
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcAddDel);

            //data.Process(2, 3, multiplyDel);
            
            //Action<T> example
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAction);

            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);


            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GenerateReports);

            //DoWork(del1);

            ////del1 += del2;
            ////del1 += del3;

            //del1 += del2 + del3;

            //int finalHours = del1(10, WorkType.GenerateReports);

            //Console.WriteLine(finalHours);

            var worker = new worker();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);

            //modified to use Delegate Inference
            //worker.WorkPerformed += Worker_WorkPerformed;

            //////mod to use Anonymous 
            ////worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            ////{
            ////    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            ////};

            //mod to use Lambda
            worker.WorkPerformed += (s,e) => Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);

//            worker.WorkCompleted += Worker_WorkCompleted;

            worker.WorkCompleted += (s,e) =>
            {
                Console.WriteLine("Worker is done");
                Console.WriteLine("Send Him Home!");
            };

            //worker.WorkCompleted -= Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

        ////static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        ////{
        ////    //    throw new NotImplementedException();
        ////    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        ////}

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GoToMeetings);
        //}

        //static int WorkPerformed1(int hours,WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        //    return hours + 1;
        //}

        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        //    return hours + 2;
        //}

        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //    return hours + 3;

        //}

    }
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
