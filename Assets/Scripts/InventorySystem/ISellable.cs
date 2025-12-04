using System;

namespace Inventory
{

	public interface ISellable
	{
		#region Properties
		public float Price { get; set; }
		public event Action<float> OnGetMoney;
		#endregion

		#region Public Methods
		public float Sell();
		#endregion

	}

}