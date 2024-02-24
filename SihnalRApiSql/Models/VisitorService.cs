using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SihnalRApiSql.DAL;
using SihnalRApiSql.Hubs;

namespace SihnalRApiSql.Models
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
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorChart = new List<VisitorChart>();
            using (var comment = _context.Database.GetDbConnection().CreateCommand())
            {
                comment.CommandText = "SELECT tarih,[1],[2],[3],[4],[5] FROM (SELECT City,CityVisitCount, CAST(VisitDate AS Date) AS tarih FROM Visitors) AS visitTable PIVOT (SUM(CityVisitCount)FOR City IN ([1], [2], [3], [4], [5])) AS pivottable ORDER BY tarih ASC;";
                comment.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = comment.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChartt = new VisitorChart();
                        visitorChartt.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                visitorChartt.Counts.Add(0);
                            }
                            else
                            {
                                visitorChartt.Counts.Add(reader.GetInt32(x));

                            }

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
