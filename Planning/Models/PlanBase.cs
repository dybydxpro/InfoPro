namespace Planning.Models;

public class PlanBase
{
    public int Id { get; set; }
    public string PO { get; set; }
    public double Quantity { get; set; }
    public DateOnly StartDate { get; set; }
}