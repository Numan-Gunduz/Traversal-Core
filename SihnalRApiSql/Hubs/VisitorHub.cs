using Microsoft.AspNetCore.SignalR;
using SihnalRApiSql.Models;

namespace SihnalRApiSql.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("ReceiveVisitorList", _visitorService.GetVisitorChartList());
        }
    }
}
