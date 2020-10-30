using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Master
/// </summary>
public class Master
{
    public Master()
    {
        ID = 0;
        FirstName = "";
        LastName = "";
        Information = "";
        Picture = null;
    }

    public Master(string fname, string lname, string info, byte[] picture, int id = 0)
    {
        ID = id;
        FirstName = fname;
        LastName = lname;
        Information = info;
        Picture = picture;
    }


    public int    ID            { get; set; }
    public string FirstName     { get; set; }
    public string LastName      { get; set; }
    public string Information   { get; set; }
    public byte[] Picture       { get; set; }

}