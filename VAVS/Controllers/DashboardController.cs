using Microsoft.AspNetCore.Mvc;
using VAVS_Data.Models;

namespace VAVS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly VAVSContext _context;
        //private readonly IDashboardServices _dashboardServices;
        //private readonly ILogger<EmployeeController> _logger;

        public DashboardController(VAVSContext context)//IDashboardServices dashboardServices ,IEmployeeServices employeeServices, IOptions<Pagination> pagination, ILogger<EmployeeController> logger
        {
            _context = context;
            //_dashboardServices = dashboardServices;
            //_employeeServices = employeeServices;
            //_pagination = pagination.Value;
            //_logger = logger;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            if (userInfo.TownshipPkid != null)
            {
                ViewData["Owner"] = _context.TbPersonalDetails.Where(x => x.StateDivisionPkid == userInfo.StateDivisionPkid && x.TownshipPkid == userInfo.TownshipPkid && x.IsDeleted == false).ToList().Count();
                ViewData["TotalPending"] = _context.TbTaxValidations.Where(x => x.QrcodeNumber == null && x.DemandNumber == null && x.PersonTownshipPkid == userInfo.TownshipPkid).ToList().Count();
                ViewData["TotalFinish"] = _context.TbTaxValidations.Where(x => x.QrcodeNumber != null && x.DemandNumber != null && x.PersonTownshipPkid == userInfo.TownshipPkid).ToList().Count();
            }
            else
            {
                ViewData["Owner"] = _context.TbPersonalDetails.Where(x => x.IsDeleted == false).ToList().Count();
                ViewData["TotalPending"] = _context.TbTaxValidations.Where(x => x.QrcodeNumber == null && x.DemandNumber == null).ToList().Count();
                ViewData["TotalFinish"] = _context.TbTaxValidations.Where(x => x.QrcodeNumber != null && x.DemandNumber != null).ToList().Count();
            }
            ViewData["TotalVehicles"] = 0;
            return View();
        }
    }
}
