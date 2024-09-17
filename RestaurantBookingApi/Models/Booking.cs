public class Booking
{
  public int Id { get; set; }
  public DateTime BookingDate { get; set; }
  public int NumberOfPeople { get; set; }

  public int TableId { get; set; }
  public Table? Table { get; set; }

  public int CustomerId { get; set; }
  public Customer? Customer { get; set; }
}
