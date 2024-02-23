using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }
        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallCisitorList", "aaa");
        }
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorChart = new List<VisitorChart>();
            using (var comment= _context.Database.GetDbConnection().CreateCommand())
            {
                comment.CommandText = "select * from crosstab('select VisitDate,City,CityVisitCount From Visitors Order By 1,2') As ct(VisitDate timestamp with time zone, City1 int,City2 int, City3 int,City4 int,City5 int);";
                comment.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = comment.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChartt = new VisitorChart();
                        visitorChartt.VisitDate=reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            visitorChartt.Counts.Add(reader.GetInt32(x));
                  
                        });
                        visitorChart.Add(visitorChartt);
                        
                    }
                }
                _context.Database.CloseConnection();
                return visitorChart;
            }
        }
    }
}
