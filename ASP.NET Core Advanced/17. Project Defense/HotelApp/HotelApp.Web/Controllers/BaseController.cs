using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Web.Controllers
{
    public class BaseController : Controller
    {

        protected bool IsGuidValid(string? id, ref Guid guid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out guid);


            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
