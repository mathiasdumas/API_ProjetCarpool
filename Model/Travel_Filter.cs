using System;
namespace CARPOOL.Model
{
	public class Travel_Filter
	{
		public int ID_Travel { get; set; }
		public Travel Travel { get; set; }
		public int ID_Filter { get; set; }
		public Filter Filter { get; set; }

	}
}

