using System;

namespace Homework5
{
    [Serializable]
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public double UnitPrice { get; set; }

        public OrderItem(int orderitemid, string productname, int productnum, double unitprice)
        {
            OrderItemId = orderitemid;
            ProductName = productname;
            ProductNum = productnum;
            UnitPrice = unitprice;
        }

        public OrderItem() { }

        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.ProductName == ProductName
                && m.ProductNum == ProductNum && m.UnitPrice == UnitPrice;
        }

        public override int GetHashCode()
        {
            return OrderItemId;
        }

        public override string ToString()
        {
            return $"商品名：{ProductName}"+$" 数量：{ProductNum}"+$" 商品单价：{UnitPrice}\n";
        }
    }
}
