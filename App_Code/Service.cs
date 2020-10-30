using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Service
/// </summary>
public class Service
{
    public Service()
    {
        Title = "";
        Description = "";
        Cost = 0.0;
        Id = 0;
        Image = null;
    }

    public Service(string title, string description, double cost, byte[] img, int id = 0)
    {
        Title = title;
        Description = description;
        Cost = cost;
        Image = img;
        Id = id;
    }

    public string Title         { get; set; }
    public string Description   { get; set; }
    public byte[] Image         { get; set; }
    public double Cost          { get; set; }
    public int    Id            { get; set; }
}