namespace RazorTutorial.Models
{
    public class MyOrders
    {
        public string Today()
        {
            return DateTime.Now.ToString();
        }
    }
}
