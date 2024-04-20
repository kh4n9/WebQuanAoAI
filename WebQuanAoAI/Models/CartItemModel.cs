
namespace WebQuanAoAI.Models
{
    public class CartItemModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
        public string Image { get; set; }
        public decimal GrandTotal { get; internal set; }
        public List<CartItemModel> CartItems { get; internal set; }

        public CartItemModel()
        {

        }
        public CartItemModel( ProductModel productModel)
        {
            ProductId = productModel.Id;
            ProductName = productModel.Name;
            Price = productModel.Price;
            Quantity = 1;
            Image = productModel.Image;

        }

    }
}
