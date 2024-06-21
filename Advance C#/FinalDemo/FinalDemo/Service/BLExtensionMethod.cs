using System.Web;

namespace FinalDemo.Service
{
    public static class BLExtensionMethod
    {
        /// <summary>
        /// Get an integer value from the form data in the HttpContext.
        /// </summary>
        /// <param name="context">The HttpContext containing the form data.</param>
        /// <param name="key">The key of the form field.</param>
        /// <returns>Returns the parsed integer value from the form data or 0 if parsing fails.</returns>
        public static int GetFormInt(this HttpContext context, string key)
        {
            string value = context.Request.Form[key];
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0; // Or throw an exception, handle it according to your needs
        }
    }
}