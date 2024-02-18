using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Querys.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	public class GuideMediatRController : Controller
	{
		private readonly IMediator _mediator;

		public GuideMediatRController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _mediator.Send(new GetAllGuideQuery());
			return View(values);
		}
		[HttpGet]
		public async Task<IActionResult> GetGuides(int id)
		{
			var values=await _mediator.Send(new GetGuideByIdQuery(id));
			return View(values);	
		}
	}
}
