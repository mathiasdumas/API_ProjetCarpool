using System;
namespace CARPOOL.Model
{
	public class Travel_Adresse
	{
		public int ID_Travel { get; set; }
		public Travel Travel { get; set; }
		public int ID_Adresse { get; set; }
		public Adresse Adresse { get; set; }
	}
}

