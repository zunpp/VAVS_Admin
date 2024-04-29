using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VAVS.Helper;
using VAVS_Data.Models;
using VAVS_Model.Model;
using VAVS_Service.Base;
using X.PagedList;

namespace VAVS.Controllers
{
    public class TaxValidationController : Controller
    {
        private readonly VAVSContext _context;
        private readonly Pagination _pagination;
        private readonly ITaxValidation _taxValidation;
        public TaxValidationController(VAVSContext context, IOptions<Pagination> pagination,ITaxValidation taxValidation)//IDashboardServices dashboardServices ,IEmployeeServices employeeServices, IOptions<Pagination> pagination, ILogger<EmployeeController> logger
        {
            _context = context;
            _taxValidation = taxValidation;
            //_employeeServices = employeeServices;
            _pagination = pagination.Value;
            //_logger = logger;
        }
        public IActionResult Index(string? VehicleNumber,string? NRC,string? Status, int? page = 1)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            var pageSize = _pagination.PageSize;
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;    
            if(userInfo.TownshipPkid!=null)
            {
                var results = _taxValidation.GetTaxValidation(VehicleNumber, NRC, Status, userInfo.TownshipPkid);
                return View(results.OrderByDescending(x => x.TaxValidationPkid).ToList().ToPagedList((int)page, pageSize));
            }
            else
            {
                var results = _taxValidation.GetTaxValidation(VehicleNumber, NRC, Status,null);
                return View(results.OrderByDescending(x => x.TaxValidationPkid).ToList().ToPagedList((int)page, pageSize));
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            var results = _taxValidation.GetTaxValidationById(Id);
            return View(results);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VM_TaxValidation taxValidation)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            _taxValidation.EditTaxValidation(taxValidation,userInfo.UserPkid);
            return RedirectToAction("Index", new {Status= "Finished" });
        }
    }
}
