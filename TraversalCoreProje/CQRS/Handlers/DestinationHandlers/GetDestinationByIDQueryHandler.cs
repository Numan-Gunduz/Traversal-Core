using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Querys.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class GetDestinationByIDQueryHandler
	{
		private readonly Context _context;

		public GetDestinationByIDQueryHandler(Context context)
		{
			_context = context;
		}
		public GetDestinationByIDQueryResult Handle(GetDestinationByIdQuery query)
		{
			var values = _context.Destinations.Find(query.id);
			return new GetDestinationByIDQueryResult
			{
				DestinationID = values.DestinationID,
				City = values.City,
				Daynight = values.DayNight,
				Price = values.Price,
			};
		}

	}
}
