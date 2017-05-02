using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RozliczanieSieNaMieszkaniu.Models;

namespace RozliczanieSieNaMieszkaniu.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var session = new SessionModel {Id = 1};
            db.Sessions.Add(session);
            db.SaveChanges();
            var model = new EntryViewModel {UserName = User.Identity.Name};
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(EntryViewModel model)
        {
            //TODO: zeby na stronie sprawdzalo czy podana wartosc to decimal
            var entry = new EntryModel()
            {
                Price = model.Price,
                Date = DateTime.Now,
                SessionId = 1,
                What = model.What,
                ApplicationUserId = User.Identity.GetUserId()
            };
            var db = new ApplicationDbContext();
            db.Entries.Add(entry);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}