using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Querys.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class GetDestinationByIDQueryHandle
	{
		private readonly Context _context;

		public GetDestinationByIDQueryHandle(Context context)
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
				Daynight = values.DayNight
			};
		}

	}
}
