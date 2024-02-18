using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class CreateDestinationCommandHandler
	{
		private readonly Context _context;

		public CreateDestinationCommandHandler(Context context)
		{
			_context = context;
		}
		public void Handle(CreateDestinationCommand command)
		{
			_context.Destinations.Add(new Destination
			{
				City = command.City,
				Price = command.Price,
				DayNight = command.DayNight,
				Capacity = command.Capacity,
				CoverImages=command.CoverImagee,
				Description="Örnek açıklama Girişi",
				Details1="Verilerin detay1 kısmı",
				Details2="Verilerin Detay2 Kısmı",
				Image2="Verilerin ikinci imaj kısmı",
				Image="Verilerin image kısmı",
				
				Status = true

			}); 
			_context.SaveChanges();
		}
	}
}
