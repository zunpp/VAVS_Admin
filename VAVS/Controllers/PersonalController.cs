using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VAVS.Helper;
using VAVS_Data.Models;
using VAVS_Service.Base;
using X.PagedList;

namespace VAVS.Controllers
{
    public class PersonalController : Controller
    {
        private readonly VAVSContext _context;
        private readonly Pagination _pagination;
        private readonly IPersonalDetail _personalDetail;
        public PersonalController(VAVSContext context, IOptions<Pagination> pagination, IPersonalDetail personalDetail)//IDashboardServices dashboardServices ,IEmployeeServices employeeServices, IOptions<Pagination> pagination, ILogger<EmployeeController> logger
        {
            _context = context;
            _personalDetail = personalDetail;
            //_employeeServices = employeeServices;
            _pagination = pagination.Value;
            //_logger = logger;
        }
        public IActionResult Index(int? page = 1)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            var pageSize = _pagination.PageSize;
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            var results = _personalDetail.GetPersonalDetail();
            return View(results.ToList().ToPagedList((int)page, pageSize));
        }
    }
}
