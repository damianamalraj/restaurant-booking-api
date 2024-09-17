public class Table
{
  public int Id { get; set; }
  public int Seats { get; set; }
  public int TableNumber { get; set; }

  public ICollection<Booking>? Bookings { get; set; }
}
