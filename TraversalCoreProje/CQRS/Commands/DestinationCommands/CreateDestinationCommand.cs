using EntityLayer.Concrete;

namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
	public class CreateDestinationCommand
	{
		public string City { get; set; }
		public string DayNight { get; set; }
		public double Price { get; set; }
		public int Capacity { get; set; }
		public string CoverImagee { get; set; }



	}
}
