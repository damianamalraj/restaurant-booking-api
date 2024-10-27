public class Booking
{
  public int Id { get; set; }
  public int TableNumber { get; set; }
  public string? CustomerName { get; set; }
  public string? CustomerEmail { get; set; }
  public int NumberOfPeople { get; set; }
  public DateTime StartBookingDateTime { get; set; }
  public DateTime EndBookingDateTime { get; set; }

  public int TableId { get; set; }
  public Table? Table { get; set; }

  public int CustomerId { get; set; }
  public Customer? Customer { get; set; }
}
