using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SihnalRApiSql.DAL;
using SihnalRApiSql.Models;

namespace SihnalRApiSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (Ecity item in Enum.GetValues(typeof(Ecity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.AddDays(x) // UTC tarih saatini kullan
                    };
                    _visitorService.SaveVisitor(newVisitor); // Asenkron olarak bekleyin
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler Başarılı Bir şekilde Eklendi");
        }

    }
}
