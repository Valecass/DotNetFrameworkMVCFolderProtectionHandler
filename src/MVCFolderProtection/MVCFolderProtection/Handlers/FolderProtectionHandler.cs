using System.IO;
using System.Net;
using System.Web;

namespace MVCFolderProtection.Handlers
{
    public class FolderProtectionHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var filePath = context.Server.MapPath(context.Request.RawUrl);
                if (File.Exists(filePath))
                {
                    var stream = File.OpenRead(filePath);
                    // stream the data from the file to  the response
                    int b;
                    context.Response.Clear();
                    context.Response.ClearHeaders();
                    context.Response.ContentType = MimeMapping.GetMimeMapping(filePath);
                    while ((b = stream.ReadByte()) != -1)
                    {
                        context.Response.OutputStream.WriteByte((byte)b);
                    }
                    context.Response.OutputStream.Flush();
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            context.Response.End();
        }
    }
}