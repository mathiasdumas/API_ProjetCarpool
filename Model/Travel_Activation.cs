using System;
namespace CARPOOL.Model
{
	public class Travel_Activation
	{
		public int ID_Travel { get; set; }
		public Travel Travel { get; set; }
		public int ID_Activation { get; set; }
		public Activation Activation { get; set; }

	}
}

