using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Review
/// </summary>
public class Review
{
    public Review()
    {
        ClientName = "";
        Text = "";
        Date = "";
    }

    public Review(string client_name, string text, string date)
    {
        ClientName = client_name;
        Text = text;
        Date = date;
    }

    public string ClientName { get; set; }
    public string Text       { get; set; }
    public string Date       { get; set; }
}