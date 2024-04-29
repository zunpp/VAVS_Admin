using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using VAVS.Helper;
using VAVS_Data.Models;
using VAVS_Model.Model;
using VAVS_Service.Base;

namespace VAVS.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VAVSContext _context;
        private readonly Pagination _pagination;
        private readonly ITaxValidation _taxValidation;
        public VehicleController(VAVSContext context, IOptions<Pagination> pagination, ITaxValidation taxValidation)//IDashboardServices dashboardServices ,IEmployeeServices employeeServices, IOptions<Pagination> pagination, ILogger<EmployeeController> logger
        {
            _context = context;
            _taxValidation = taxValidation;
            //_employeeServices = employeeServices;
            _pagination = pagination.Value;
            //_logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SetupStandardValue()
        {
            var userId = HttpContext.User.Identity.Name;
            var userInfo = _context.TbUsers.Where(x => x.UserPkid == Convert.ToInt32(userId)).FirstOrDefault();
            ViewBag.lstLogIn = userInfo;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SetupStandardValue(VM_SetUpStandardValue standardValue)
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
                    string apiUrl = "http://203.81.89.218:99/VehicleStandardAPI/api/VehicleStandard/";

                    // Serialize the model to JSON
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(standardValue);

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
                        return Content("API call successful. Response: " + responseBody);
                    }
                    else
                    {
                        // If the API call was not successful, handle the error
                        return Content("API call failed with status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the API call
                return Content("An error occurred: " + ex.Message);
            }
            return View();
        }
    }
}
