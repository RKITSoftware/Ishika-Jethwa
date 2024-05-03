using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Exception.MAL
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestID => !string.IsNullOrEmpty(RequestId);

        public string ExceptionMsg { get; set; }

        public void onGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                ExceptionMsg = "File not Found";

            }
            if (exceptionHandlerPathFeature?.Path == "/")
            {
                ExceptionMsg ??= string.Empty;
                ExceptionMsg += "Page : Home";
            }
        }
    }
}
