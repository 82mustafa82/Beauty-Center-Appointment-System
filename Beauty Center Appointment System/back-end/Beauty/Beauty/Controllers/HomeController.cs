using Beauty.Data;
using Beauty.Models;
using Beauty.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Beauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly BeautyContext _context;

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _context = new BeautyContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Randevu()
        {
            string uyeJson = TempData["UyeTemp"].ToString();
            Uye uye = JsonConvert.DeserializeObject<Uye>(uyeJson);
            TempData.Keep("UyeTemp");
            return View(uye);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetServices()
        {
            return Json(_context.Hizmets.Select(x => x.Had).ToList());
        }

        [HttpPost]
        public async void SendMail(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
            {
                return;
            }
            else
            {
                MailRequest req = new MailRequest { ToEmail = to, Subject = subject, Body = body, Attachments = new List<IFormFile>() };
                await _mailService.SendEmailAsync(req);
            }
        }

        [HttpPost]
        public IActionResult TryLogin(LoginModel lm)
        {
            if (TempData.Any())
            {
                TempData.Remove("UyeTemp");
            }

            if (lm != null)
            {
                if (lm.Username == "admin" && lm.Password == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Uye uye = _context.Uyes.Where(x => x.Email == lm.Username && x.Sifre == lm.Password).FirstOrDefault();

                    if (uye?.Uid > 0)
                    {
                        TempData.Add("UyeTemp", JsonConvert.SerializeObject(uye));
                        return RedirectToAction("Randevu");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetServicesForDropdown()
        {
            return Json(_context.Hizmets.ToList());
        }
        [HttpGet]
        public JsonResult GetPersonel()
        {
            return Json(_context.Calisans.ToList());
        }
        [HttpPost]
        public JsonResult RandevuKaydet(int uid, int cid, int sid, string dateStr)
        {

            try
            {
                Data.Randevu r = new Randevu { Uid = uid, Cid = cid, Hno = sid, Tarih = Convert.ToDateTime(dateStr) };
                _context.Randevus.Add(r);
                _context.SaveChanges();

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("Ad,Soyad,Uid,Cinsiyet,Email,Sifre,Telefon")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uye);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(uye);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}