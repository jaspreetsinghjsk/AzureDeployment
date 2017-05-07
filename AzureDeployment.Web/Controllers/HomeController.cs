using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzureDeployment.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult DeployArm()
        {
            var storageAccount = CloudStorageAccount.Parse(Program.Configuration["AzureWebJobsStorage"].ToString());
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("DeployArm");
            Task.Run(() => queue.AddMessageAsync(new CloudQueueMessage("TriggerTemplate" + DateTime.Now.ToString("yyyyMMDDhhmm"))));

            return View();
        }
    }
}
