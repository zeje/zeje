using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading;

namespace Zeje.WFA
{

    class Program
    {
        static void Main(string[] args)
        {
            //Activity workflow1 = new Workflow1();
            //WorkflowInvoker.Invoke(workflow1);
            //Console.ReadLine();

            //string wfData = Console.ReadLine();

            ////这里用Dictionary类型，因为Invoke重载接受这种键值对的类型
            //Dictionary<string, object> wfArgs = new Dictionary<string, object>();

            ////使用键值对，键为我们刚才加的参数名称,将数据存入到字典中
            //wfArgs.Add("Text", wfData);

            //AutoResetEvent waitHandler = new AutoResetEvent(false);
            ////传递给工作流
            //WorkflowApplication app = new WorkflowApplication(new Activity1(), wfArgs);
            ////将事件与app挂钩，当工作流结束前，通知其他线程，并打印一条信息
            //app.Completed = (completedArgs) =>
            //{
            //    waitHandler.Set();
            //    Console.WriteLine("the workflow is done");
            //};
            ////开启工作流
            //app.Run();
            ////在工作流程结束之前一直等待
            //waitHandler.WaitOne();
            //Console.WriteLine("结束了");
            //Console.Read();

            //Dictionary<string, object> wlData = new Dictionary<string, object>();
            //wlData.Add("ProductName", "小米手机青春版");
            //wlData.Add("InventoryState", "Yes，请输入是否可以购买 Y/N");
            //WorkflowInvoker.Invoke(new Activity2(), wlData);

            //Activity demoActivity = new OrderWF();
            //WorkflowInvoker.Invoke(demoActivity);

            Order myOrder = new Order()
            {
                OrderID = 1,
                Description = "Need some stuff",
                ShippingMethod = "2ndDay",
                TotalWeight = 100
            };
            IDictionary<string, object> input = new Dictionary<string, object>
            {
                {"OrderInfo", myOrder}
            };
            //execute the workflow
            IDictionary<string, object> output = WorkflowInvoker.Invoke(new OrderWF(), input);
            //Get the TotalAmount returned by workflow
            decimal total = (decimal)output["TotalAmount"];
            Console.WriteLine("Workflow return ${0} for my order total", total);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
