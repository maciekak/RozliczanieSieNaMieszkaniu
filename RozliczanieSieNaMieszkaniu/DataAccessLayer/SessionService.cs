using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RozliczanieSieNaMieszkaniu.Models;

namespace RozliczanieSieNaMieszkaniu.DataAccessLayer
{
    public class SessionService
    {
        private readonly ApplicationDbContext _applicationDb;

        public SessionService()
        {
            _applicationDb = new ApplicationDbContext();
        }

        public int GetActualSessionId(HttpContext context)
        {
            var manager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            
            return manager.FindById(context.User.Identity.GetUserId()).ActualSession;
        }

        public SessionModel GetSession(int sessionId)
        {
            return _applicationDb.Sessions.First(s => s.Id == sessionId);
        }

        public SessionModel GetActualSession(HttpContext context)
        {
            return GetSession(GetActualSessionId(context));
        }

        public void SetUpNewSession(HttpContext context, List<FiguredCostsUpViewModel> figuredCostsList)
        {
            if (!context.User.IsInRole("Admin"))
                throw new Exception("Access only for Admin");

            var manager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var admin = manager.FindById(context.User.Identity.GetUserId());

            int actualSessionId = admin.ActualSession;

            var actualSession = _applicationDb.Sessions.First(s => s.Id == actualSessionId);

            //TODO: it should search by users not entries!!!
            var users = actualSession.Entries
                    .Select(e => e.User)
                    .Where(e => e.ActualSession == actualSessionId)
                    .Distinct().ToList();

            var endSessionList = figuredCostsList.Select(f => new EndSessionModel()
            {
                Who = f.Who,
                Whom = f.Whom,
                HowMuch = f.HowMuch,
                Realized = false,
                Date = DateTime.Now,
                SessionId = actualSessionId
            }).ToList();

            var newSession = new SessionModel();
            _applicationDb.Sessions.Add(newSession);
            _applicationDb.EndSessions.AddRange(endSessionList);

            int newSessionId = _applicationDb.Sessions.Max(s => s.Id);

            admin.ActualSession = newSessionId;
            users.ForEach(u => u.ActualSession = newSessionId);
            _applicationDb.SaveChanges();
        }
    }
}