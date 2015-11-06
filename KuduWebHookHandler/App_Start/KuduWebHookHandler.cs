using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace KuduWebHookHandler.App_Start
{
    public class KuduWebHookHandler : WebHookHandler
    {
        public KuduWebHookHandler()
        {
            Receiver = "kudu";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Convert to POCO type
            KuduNotification notification = context.GetDataOrDefault<KuduNotification>();

            // Get the notification message
            string message = notification.Message;

            // Get the notification author
            string author = notification.Author;

            Trace.TraceInformation($"Author: {author}, message: {message}");

            return Task.FromResult(true);
        }
    }
}
