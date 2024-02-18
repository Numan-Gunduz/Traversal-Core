using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Querys.GuideQueries
{
	public class GetGuideByIdQuery:IRequest<GetGuideByQueryResult>
	{
		public GetGuideByIdQuery(int ıd)
		{
			this.ıd = ıd;
		}

		public int ıd { get; set; }
    }
}
