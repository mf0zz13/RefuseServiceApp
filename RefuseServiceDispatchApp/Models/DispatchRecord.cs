namespace RefuseServiceDispatchApp.Models;

public class DispatchRecord
{
    public DateTime Date { get; set; }
    public int ServiceArea { get; set; }
    public int Route { get; set; }
    public int TruckNumber { get; set; }
    public int Driver { get; set; }
    public int HelperOne { get; set; }
    public int HelperTwo { get; set; }
    public int RefuseType { get; set; }
}
