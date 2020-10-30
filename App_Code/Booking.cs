using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Booking
/// </summary>
public class Booking
{
    public Booking()
    {
        BookingStatus = "";
        MasterFirstName = "";
        MasterLastName = "";
        ServiceTitle = "";
        ServiceCost = 0.0;
        ServiceDateTime = "";
        Id = 0;
    }

    public Booking(string status, string mfn, string mln, 
                   string stitle, double scost, string datetime, int id)
    {
        BookingStatus = status;
        MasterFirstName = mfn;
        MasterLastName = mln;
        ServiceTitle = stitle;
        ServiceCost = scost;
        ServiceDateTime = datetime;
        Id = id;
    }

    public int    Id                { get; set; }
    public string BookingStatus     { get; set; }
    public string MasterFirstName   { get; set; }
    public string MasterLastName    { get; set; }
    public string ServiceTitle      { get; set; }
    public double ServiceCost       { get; set; }
    public string ServiceDateTime   { get; set; }

}