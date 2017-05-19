using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RozliczanieSieNaMieszkaniu.BusinessLogic;
using RozliczanieSieNaMieszkaniu.DataAccessLayer;
using RozliczanieSieNaMieszkaniu.Models;

namespace RozliczanieSieNaMieszkaniu.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sessionService = new SessionService();
            //TODO: zeby jeszcze pobieralo z aktualnej sesji
            var model = new EntriesViewModel()
            {
                EntryList = sessionService.GetActualSessionEntries(System.Web.HttpContext.Current),
                NewEntry = new EntryViewModel()
                {
                    UserName = User.Identity.GetUserId()
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(EntryViewModel model)
        {
            var sessionService = new SessionService();

            //TODO: zeby na stronie sprawdzalo czy podana wartosc to decimal
            var entry = new EntryModel()
            {
                Price = model.Price,
                Date = DateTime.Now,
                SessionId = sessionService.GetActualSessionId(System.Web.HttpContext.Current),
                What = model.What,
                ApplicationUserId = User.Identity.GetUserId()
            };
            var db = new ApplicationDbContext();
            db.Entries.Add(entry);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Summary()
        {
            var sessionService = new SessionService();
            var actualSession = sessionService.GetActualSession(System.Web.HttpContext.Current);
            var reckoningService = new ReckoningCostsService();
            var model = reckoningService.GetFiguredCostsUpList(actualSession);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SummaryForAdmin()
        {
            //TODO: it possible to take that from model
            var sessionService = new SessionService();
            var actualSession = sessionService.GetActualSession(System.Web.HttpContext.Current);
            var reckoningService = new ReckoningCostsService();
            var figuredUpList = reckoningService.GetFiguredCostsUpList(actualSession);

            sessionService.SetUpNewSession(System.Web.HttpContext.Current, figuredUpList);

            return RedirectToAction("Summary");
        }
    }
}