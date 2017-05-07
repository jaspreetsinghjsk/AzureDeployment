using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDeployment.WebJob
{
    public class Functions
    {
        public static void GenerateThumbnail(
        [QueueTrigger("armdeployrequest")] string resourceGroupName)
        {
        }
    }
}
