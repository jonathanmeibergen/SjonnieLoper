namespace SjonnieLoper.Reservations.ViewModels
{
    public class ReservationViewModel : 
        {

            public int Id { get; set; }
            public DateTime Orderdate { get; set; }
            public string Whiskey { get; set; }
            //TODO: Choose single of two derived classes.
            public Customer CustomerOrder { get; set; }
        
            public Reservation()
            {
                Id = id;
                Orderdate = time;
                CustomerOrder = customer;
                Whiskey = whiskey;
            }

            public Reservation()
            {
            
            }

        } 
}