using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using RozliczanieSieNaMieszkaniu.Models;
using WebGrease.Css.Extensions;

namespace RozliczanieSieNaMieszkaniu.BusinessLogic
{
    public class ReckoningCostsService
    {
        private static Dictionary<string, decimal> GetUsersSpendings(SessionModel session)
        {
            var usersSpendings = new Dictionary<string, decimal>();

            foreach (var entry in session.Entries)
            {
                var userId = entry.ApplicationUserId;

                if (usersSpendings.ContainsKey(userId))
                    usersSpendings[userId] += entry.Price;
                else
                    usersSpendings.Add(userId, entry.Price);
            }
            return usersSpendings;
        }

        public List<EndSessionModel> GetTransactionsList(SessionModel session)
        {
            var figuredCostsUpList = GetFiguredCostsUpList(session);

            var endSessionList = figuredCostsUpList.Select(u => new EndSessionModel()
            {
                Who = u.Who,
                Whom = u.Whom,
                HowMuch = u.HowMany,
                Realized = false,
                SessionId = session.Id
            }).ToList();

            return endSessionList;
        }

        public List<FiguredCostsUpViewModel> GetFiguredCostsUpList(SessionModel session)
        {
            //TODO: napisac testy
            var usersSpendings = GetUsersSpendings(session);

            decimal average = usersSpendings.Average(s => s.Value);

            var lessThanAverage = usersSpendings.Where(u => u.Value < average).OrderBy(u => u.Value).ToList();
            var moreThanAverage = usersSpendings.Where(u => u.Value > average).OrderByDescending(u => u.Value).ToList();
            
            var figuredCostsList = new List<FiguredCostsUpViewModel>();

            var more = moreThanAverage.First();
            var less = lessThanAverage.First();

            decimal payBack = more.Value - average;
            decimal restToAverage = average - less.Value;

            while (lessThanAverage.Any() && moreThanAverage.Any())
            {
                if (payBack - restToAverage > 0)
                {
                    payBack -= restToAverage;
                    figuredCostsList.Add(new FiguredCostsUpViewModel()
                    {
                        Who = less.Key,
                        Whom = more.Key,
                        HowMany = restToAverage
                    });

                    lessThanAverage.Remove(less);

                    if (lessThanAverage.Count == 0)
                        continue;

                    less = lessThanAverage.First();
                    restToAverage = average - less.Value;
                }

                else
                {
                    restToAverage -= payBack;
                    figuredCostsList.Add(new FiguredCostsUpViewModel()
                    {
                        Who = less.Key,
                        Whom = more.Key,
                        HowMany = payBack
                    });

                    moreThanAverage.Remove(more);

                    if (moreThanAverage.Count == 0)
                        continue;

                    more = moreThanAverage.First();
                    payBack = more.Value - average;
                }
            }

            return figuredCostsList;
        }
    }
}