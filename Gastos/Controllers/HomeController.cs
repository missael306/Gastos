using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gastos.Models;
using Gastos.Data;
using Newtonsoft.Json;
using Gastos.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Gastos.Controllers
{
    public class HomeController : Controller
    {

        #region Attrributes    
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly HomeBusiness _homeBusiness;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration configuration;
        #endregion

        #region CONSTRUCT
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _homeBusiness = new HomeBusiness(context);
            this.configuration = configuration;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
        
        #region INDEX 
        [Authorize]
        public IActionResult Index(string lstAlertsSerialized = "")
        {
            //Alerts list
            List<Alert> lstAlerts = new List<Alert>();
            if (TempData[SessionKeys.Alerts] is string lstAlertTemp)
            {
                lstAlerts = JsonConvert.DeserializeObject<List<Alert>>(lstAlertTemp);
            }
            ViewBag.lstAlerts = lstAlerts;

            //Models            
            ViewBag.modelfrmAddTransaction = new Transaction();
            ViewBag.modelfrmAddCategory = new Category();

            //Catalogs
            string userId = _userManager.GetUserId(User);
            ICollection<Category> lstCategories = _homeBusiness.LstCategories(userId);
            ViewBag.lstCategories = lstCategories;
            ICollection<Icon> lstCatIcons = _homeBusiness.LstIcons();
            ViewBag.lstIcons = lstCatIcons;
            
            return View();
        }

        [HttpPost]
        public JsonResult Balance(DateTime start, DateTime end)
        {
            string userId = _userManager.GetUserId(User);
            decimal expenses = _homeBusiness.LstTransactions(1, start, end, userId).Sum(x => x.Value);
            decimal deposits = _homeBusiness.LstTransactions(2, start, end, userId).Sum(x => x.Value);
            Balance balance = new Balance(deposits, expenses);
            return Json(data: balance);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction model)
        {
            //Add new Transacction
            List<Alert> lstAlerts = new List<Alert>();
            if (ModelState.IsValid)
            {
                model.User = await _userManager.GetUserAsync(User);
                if (_homeBusiness.AddTrasaction(model))
                    lstAlerts.Add(new Alert("success", "Transacción registrada correctamente."));
            }
            else
            {
                foreach (var error in ModelState.Values.Where(x => x.Errors.Count > 0))
                    foreach (var msg in error.Errors)
                        lstAlerts.Add(new Alert("warning", msg.ErrorMessage));
            }
            var tempAlerts = JsonConvert.SerializeObject(lstAlerts.ToList());
            TempData[SessionKeys.Alerts] = tempAlerts;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category model)
        {
            //Add new Category            
            List<Alert> lstAlerts = new List<Alert>();
            if (ModelState.IsValid)
            {
                model.User = await _userManager.GetUserAsync(User);
                if (_homeBusiness.AddCategory(model))
                    lstAlerts.Add(new Alert("success", "Categoría registrada correctamente."));
            }
            else
            {
                foreach (var error in ModelState.Values.Where(x => x.Errors.Count > 0))
                    foreach (var msg in error.Errors)
                        lstAlerts.Add(new Alert("warning", msg.ErrorMessage));
            }
            var tempAlerts = JsonConvert.SerializeObject(lstAlerts.ToList());
            TempData[SessionKeys.Alerts] = tempAlerts;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult LstCategoriesByTypeTransaction(int idTypeTransaction)
        {
            string userId = _userManager.GetUserId(User);
            ICollection<Category> lstCetegories = _homeBusiness.LstCategories(idTypeTransaction, userId);
            return Json(data: lstCetegories);
        }

        [HttpPost]
        public JsonResult ExpensesDay(DateTime start, DateTime end)
        {
            string userId = _userManager.GetUserId(User);
            List<Expense> lstExpenses = _homeBusiness.LstExpensesDay(start, end, userId);
            return Json(data: lstExpenses);
        }

        [HttpPost]
        public IActionResult ExpensesDayDetails()
        {
            return PartialView("_expensesDayDetails");
        }

        [HttpPost]
        public JsonResult LstExpensesDay(DateTime day)
        {
            string userId = _userManager.GetUserId(User);
            List<Transaction> lstDeposits = _homeBusiness.LstTransactions(2, day, day, userId);
            List<Transaction> lstExpenses = _homeBusiness.LstTransactions(1, day, day, userId);
            List<Transaction> lstTotal = new List<Transaction>();
            lstTotal.AddRange(lstDeposits);
            lstTotal.AddRange(lstExpenses);
            return Json(new { data = lstTotal });
        }
        #endregion
    }
}
