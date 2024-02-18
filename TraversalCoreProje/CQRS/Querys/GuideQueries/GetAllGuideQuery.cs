using MediatR;
using TraversalCoreProje.CQRS.Results.DestinationResults;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Querys.GuideQueries
{
	public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
	{

	}
}
