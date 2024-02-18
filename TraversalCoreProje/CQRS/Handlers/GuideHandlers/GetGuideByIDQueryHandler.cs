using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Querys.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
	public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByQueryResult>
	{
		private readonly Context _context;

		public GetGuideByIDQueryHandler(Context context)
		{
			_context = context;
		}

		public async Task<GetGuideByQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _context.Guides.FindAsync(request.ıd);
			return new GetGuideByQueryResult
			{
				GuideID = values.GuideID,
				Description = values.Description,
				Name = values.Name,
			};
		}
	}
}
