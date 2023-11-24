using Ecom.DataAccess.services;
using Ecom.Models;
using Ecom.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RzEcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HolidayController : Controller
    {
        private readonly IBlogPosyApiService _publicHolidaysApiService;

        public HolidayController(IBlogPosyApiService publicHolidaysApiService)
        {
            _publicHolidaysApiService = publicHolidaysApiService;
        }
        public async Task<IActionResult> Index()
        {
            List<BlogPost> holidays = new List<BlogPost>();
            holidays = await _publicHolidaysApiService.GetBlogPosts();

            return View(holidays);
        }
    }
}
