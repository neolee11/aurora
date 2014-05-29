namespace Domain.Shopping
{
    public enum EOrderStatus
    {
        Unknown = 0, //unknown state
        Processing, //order in processing state
        Shipped, //order shipped to customer
        Cancelled //order cancelled by customer before shipping
    }
}
