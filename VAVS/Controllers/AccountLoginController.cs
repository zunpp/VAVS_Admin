using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VAVS_Data.Models;

namespace VAVS.Controllers
{
    public class AccountLoginController : Controller
    {
        private readonly VAVSContext _context;
        //private readonly ILogger<AccountLoginController> _logger;

        public AccountLoginController(VAVSContext context)//, ILogger<AccountLoginController> logger
        {
            _context = context;
            // _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            TimeSpan.FromDays(-30);
            return RedirectToAction("Login", "AccountLogin");
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)//string username, string password
        {

            try
            {
                var userInfo = _context.TbUsers.Where(x => x.UserId == username && x.Password == Encrypt(password)).FirstOrDefault();
                //if (userInfo.AccountCloseStatus == true)
                //{
                //    ViewBag.Error = "Your Account Temporary Close bacause Monthly Account Closing Process Running!!!";
                //}
                //else
                //{
                if (userInfo != null)
                {
                    //MappedDiagnosticsLogicalContext.Set("userId", userInfo.UserPkid);

                    //var userActivate = _context.TbUsers.Where(x => x.UserId == username && x.Password == Encrypt(password)).FirstOrDefault();
                    if (userInfo != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, Convert.ToString(userInfo.UserPkid),ClaimValueTypes.Integer64)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, "Login");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        //_logger.LogInformation("Successfully Login");
                        //if (userInfo.AccountType == "Head Admin" || userInfo.AccountType == "Super Admin")
                        //    return RedirectToAction("AdminDivisionIndex", "Employee");
                        //else
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ViewBag.Error = "Your account is not activate!";
                    }


                }
                else
                {
                    ViewBag.Error = "Your UserName or Password Wrong!";

                }
                // }
                //var pass = MADBHR.Helper.EncryptAndDecrypt.Decrypt(userInfo.Password, username.Trim() + "MADB").Equals(password);

            }
            catch (Exception ex)
            {

            }

            return View();

        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "P9n$!0n9r";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
