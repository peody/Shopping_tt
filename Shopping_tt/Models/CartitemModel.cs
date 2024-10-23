using System.Drawing;

namespace Shopping_tt.Models
{
	public class CartitemModel
	{
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quality { get; set; }
		public decimal Price { get; set; }
		public string Image {  get; set; }
		public decimal Total
		{
			get { return Quality * Price; }
		}
		public CartitemModel()
		{

		}
		public CartitemModel(ProductModel product)
		{
			ProductId = product.Id;
			ProductName = product.Name;
			Price = product.Price;
			Quality = 1;
			Image = product.Image;
		}
	}
}
