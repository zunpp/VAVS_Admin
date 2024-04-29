using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nancy.Json;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using VAVS.Helper;
using VAVS_Data.Models;
using VAVS_Model.Model;
using VAVS_Service.Base;
using X.PagedList;

namespace VAVS.Controllers
{
    public class VehicleStandardValueController : Controller
    {
        private readonly VAVSContext _context;
        private readonly Pagination _pagination;
        private readonly ITaxValidation _taxValidation;
        public VehicleStandardValueController(VAVSContext context, IOptions<Pagination> pagination, ITaxValidation taxValidation)//IDashboardServices dashboardServices ,IEmployeeServices employeeServices, IOptions<Pagination> pagination, ILogger<EmployeeController> logger
        {
            _context = context;
            _taxValidation = taxValidation;
            //_employeeServices = employeeServices;
            _pagination = pagination.Value;
            //_logger = logger;
        }
        public IActionResult Index(int? page = 1)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;


            string apiUrl = "http://203.81.89.218:99/VehicleStandardAPI/api/VehicleStandard/GetVehicleStandardValueList?apiKey=" + "V3H!cl3$t@ND@rd";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            string json = client.DownloadString(apiUrl);

            var results = (new JavaScriptSerializer()).Deserialize<List<VM_SetUpStandardValue>>(json);
            //return Json(v);
            if (userInfo.TownshipPkid == null || userInfo.TownshipPkid == 0)
            {
                ViewData["Township"] = null;

            }
            else
            {
                ViewData["Township"] = userInfo.TownshipPkid;

            }
            var pageSize = _pagination.PageSize;
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            // List<VM_SetUpStandardValue> results = new List<VM_SetUpStandardValue>();
            return View(results.ToList().ToPagedList((int)page, pageSize));
        }
        [HttpGet]
        public IActionResult Create(string? Manufacturer = null, string? BuildType = null, string? FuelType = null, string? VehicleBrand = null, string? ModelYear = null, string? EnginePower = null)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_SetUpStandardValue modelValue)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            try
            {
                // Create an instance of HttpClient
                using (HttpClient httpClient = new HttpClient())
                {
                    // Specify the API endpoint URL
                    string apiUrl = "http://203.81.89.218:99/VehicleStandardAPI/api/VehicleStandard/AddVehicleStandardMasterValue?apiKey=" + "V3H!cl3$t@ND@rd";

                    // Serialize the model to JSON
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(modelValue);

                    // Create StringContent with the serialized JSON
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send the POST request to the API
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Return a success message or further process the response
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // If the API call was not successful, handle the error
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the API call
                return Content("An error occurred: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            string apiUrl = "http://203.81.89.218:99/VehicleStandardAPI/api/VehicleStandard/GetVehicleStandardValueById?apiKey=" + "V3H!cl3$t@ND@rd" + "&Id=" + Id;
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            string json = client.DownloadString(apiUrl);

            var results = (new JavaScriptSerializer()).Deserialize<VM_SetUpStandardValue>(json);

            return View(results);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(VM_SetUpStandardValue modelValue)
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            try
            {
                // Create an instance of HttpClient
                using (HttpClient httpClient = new HttpClient())
                {
                    // Specify the API endpoint URL
                    string apiUrl = "http://203.81.89.218:99/VehicleStandardAPI/api/VehicleStandard/UpdateVehicleStandardMasterValue?apiKey=" + "V3H!cl3$t@ND@rd";

                    // Serialize the model to JSON
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(modelValue);

                    // Create StringContent with the serialized JSON
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send the POST request to the API
                    HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Return a success message or further process the response
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // If the API call was not successful, handle the error
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the API call
                return Content("An error occurred: " + ex.Message);
            }
        }

    }
}
