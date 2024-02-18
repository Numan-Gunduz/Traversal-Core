using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _queryHandler;
        private readonly GetDestinationByIDQueryHandle _getDestinationByIDQueryHandle;
		public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIDQueryHandle getDestinationByIDQueryHandle)
		{
			_queryHandler = queryHandler;
			_getDestinationByIDQueryHandle = getDestinationByIDQueryHandle;
		}

		public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandle.Handle(new CQRS.Querys.DestinationQueries.GetDestinationByIdQuery (id));
            return View(values);
        }
    }
}
