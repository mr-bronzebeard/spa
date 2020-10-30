using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Client
/// </summary>
public class Client
{
    public Client()
    {
        Id = 0;
        FirstName = "";
        LastName = "";
        FatherName = "";
        Email = "";
        Password = "";
        CreditCard = "";
    }

    public Client(string fname, string lname, string faname, 
                  string email, string pass, string credit, int id = 0)
    {
        Id = id;
        FirstName = fname;
        LastName = lname;
        FatherName = faname;
        Email = email;
        Password = pass;
        CreditCard = credit;
    }

    public int    Id            { get; set; }
    public string FirstName     { get; set; }
    public string LastName      { get; set; }
    public string FatherName    { get; set; }
    public string Email         { get; set; }
    public string Password      { get; set; }
    public string CreditCard    { get; set; }
}