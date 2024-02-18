using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class RemoveDestinationCommandHandler
	{
		private readonly Context _context;

		public RemoveDestinationCommandHandler(Context context)
		{
			_context = context;
		}
		public void Handle(RemoteDestinationCommands commands)
		{
			var values = _context.Destinations.Find(commands.Id);
			_context.Destinations.Remove(values);
			_context.SaveChanges();
		}
	}
}
