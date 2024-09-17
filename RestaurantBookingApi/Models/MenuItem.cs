using Microsoft.EntityFrameworkCore;

public class MenuItem
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public bool IsAvailable { get; set; }

  [Precision(18, 2)]
  public decimal Price { get; set; }
}
