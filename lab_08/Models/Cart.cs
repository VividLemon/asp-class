using System.Linq;
using System.Collections.Generic;
namespace Lab_06.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddCartItem (Video video)
        {
            CartLine line = lineCollection.Where(el => el.Video.VideoId == video.VideoId).FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine { Video = video });
            }
        }

        public virtual void RemoveCartItem(Video video) => lineCollection.RemoveAll(el => el.Video.VideoId == video?.VideoId);
        public virtual decimal TotalCartValue() => lineCollection.Sum(el => el.Video.Price);
        public virtual void ClearCart() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Video Video { get; set; }
    }
}
