using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Сводное описание для Model
/// </summary>
public class Model
{
    public Model()
    {

    }

    public static void AddClient(Client client)
    {
        string query = "insert into Client(FirstName, LastName, FatherName, Email, Password, CreditCard) " +
                       "values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}');";

        OpenConnection();
        query = String.Format(query, client.FirstName, client.LastName, client.FatherName, client.Email, client.Password, client.CreditCard);
        new SqlCommand(query, connection).ExecuteNonQuery();
        CloseConnection();
    }

    public static Client GetClient(string email, string pass)
    {
        Client client = null;

        var query = "select * from client where Email='{0}' and Password='{1}'";

        OpenConnection();
        var reader = new SqlCommand(String.Format(query, email, pass), connection).ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            client = new Client();
            client.Id = (int) reader[0];
            client.FirstName = (string) reader[1];
            client.LastName = (string)reader[2];
            client.FatherName = (string)reader[3];
            client.Email = (string)reader[4];
            client.Password = (string)reader[5];
            client.CreditCard = (string)reader[6];
        }

        CloseConnection();
        return client;
    }
   

    public static void AddMaster(string fname, string lname, string info, byte[] image)
    {
        var query = "insert into Master(FirstName, LastName, Information, MasterImage) " +
                    "values(N'{0}', N'{1}', N'{2}', @img);";

        OpenConnection();
        var cmd = new SqlCommand(String.Format(query, fname, lname, info), connection);
        cmd.Parameters.Add(new SqlParameter("@img", image));    // This parameter is for image
        cmd.ExecuteNonQuery();
        CloseConnection();
    }
    
    public static List<Master> GetMasters()
    {
        List<Master> masters = new List<Master>();

        OpenConnection();

        var reader = new SqlCommand("select * from Master;", connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                masters.Add(new Master((string)reader[1], (string)reader[2], (string)reader[3], (byte[])reader[4], (int)reader[0]));
            }
        }

        CloseConnection();

        return masters;
    }

    public static Master GetMasterByID(int id)
    {
        Master master = null;

        OpenConnection();
        var reader = new SqlCommand(String.Format("select * from Master where id = {0};", id), connection).ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            master = new Master((string)reader[1], (string)reader[2], (string)reader[3], (byte[])reader[4], (int)reader[0]);
        }

        CloseConnection();
        return master;
    }
    
    public static List<Review> GetMasterReview(int id)
    {
        List<Review> list = new List<Review>();

        OpenConnection();

        var query = "select FirstName, LastName, Review, ReviewDate " +
                    "from MasterReview join Client on MasterReview.ClientID = Client.Id where MasterId = " + id + ";";

        var reader = new SqlCommand(query, connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                list.Add(new Review( (string)reader[0] + " " + (string)reader[1], (string)reader[2], (string)reader[3]));
            }
        }

        CloseConnection();

        return list;
    }
    
    public static void AddMasterReview(int client_id, int master_id, string review)
    {
        var query = "insert into MasterReview(MasterId, ClientId, Review, ReviewDate) " +
                    "values({0}, {1}, N'{2}', N'{3}');";

        var date = "" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

        OpenConnection();
        new SqlCommand(String.Format(query, master_id, client_id, review, date), connection).ExecuteNonQuery();
        CloseConnection();
    }



    public static void AddService(string title, string descripton, double cost, byte[] image)
    {
        var query = "insert into Service(Title, Description, ServiceCost, Picture) " +
                    "values(N'{0}', N'{1}', {2}, @img);";

        OpenConnection();
        var cmd = new SqlCommand(String.Format(query, title, descripton, ("" + cost).Replace(",", ".")), connection);
        cmd.Parameters.Add(new SqlParameter("@img", image));    // This parameter is for image
        cmd.ExecuteNonQuery();
        CloseConnection();
    }

    public static List<Service> GetServices()
    {
        List<Service> services = new List<Service>();

        OpenConnection();

        var reader = new SqlCommand("select * from Service;", connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                services.Add(new Service((string)reader[1], (string)reader[2], (double)reader[3], (byte[])reader[4], (int)reader[0]));
            }
        }

        CloseConnection();

        return services;
    }

    public static List<Service> GetServicesByMasterId(int master_id)
    {
        List<Service> services = new List<Service>();

        string command = "select Service.id, Title, Description, ServiceCost, Picture " +
                         "from Service " +
                         "join MasterService " +
                         "on MasterService.ServiceId = Service.Id " +
                         "where MasterService.MasterId = " + master_id + ";";
        OpenConnection();

        var reader = new SqlCommand(command, connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                services.Add(new Service((string)reader[1], (string)reader[2], (double)reader[3], (byte[])reader[4], (int)reader[0]));
            }
        }

        CloseConnection();

        return services;
    }

    public static Service GetServiceByID(int id)
    {
        Service service = null;

        OpenConnection();
        var reader = new SqlCommand(String.Format("select * from Service where id = {0};", id), connection).ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            service = new Service((string)reader[1], (string)reader[2], (double)reader[3], (byte[])reader[4], (int)reader[0]);
        }

        CloseConnection();
        return service;
    }

    public static List<Review> GetServiceReview(int id)
    {
        List<Review> list = new List<Review>();

        OpenConnection();

        var query = "select FirstName, LastName, Review, ReviewDate " +
                    "from ServiceReview join Client on ServiceReview.ClientID = Client.Id where ServiceId = " + id + ";";

        var reader = new SqlCommand(query, connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                list.Add(new Review((string)reader[0] + " "+ (string)reader[1], (string)reader[2], (string)reader[3]));
            }
        }

        CloseConnection();

        return list;
    }

    public static void AddServiceReview(int client_id, int service_id, string review)
    {
        var query = "insert into ServiceReview(ServiceId, ClientId, Review, ReviewDate) " +
                    "values({0}, {1}, N'{2}', N'{3}');";

        var date = "" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

        OpenConnection();
        new SqlCommand(String.Format(query, service_id, client_id, review, date), connection).ExecuteNonQuery();
        CloseConnection();
    }


    public static void AddMasterServiceRelation(int master_id, int service_id)
    {
        var query = String.Format("insert into MasterService(MasterId, ServiceId) " +
            "values({0}, {1});", master_id, service_id);
        OpenConnection();
        new SqlCommand(query, connection).ExecuteNonQuery();
        CloseConnection();
    }


    public static void AddBooking(int client_id, int master_id, int service_id, string datetime)
    {
        var query = "insert into Booking(ClientId, ServiceId, MasterId, DateTime, BookingStatus) " +
                    " values({0}, {1}, {2}, N'{3}', N'{4}');";

        OpenConnection();

        new SqlCommand(String.Format(query, client_id, service_id, master_id, datetime, BookingStatus.BOOKED), connection).ExecuteNonQuery();

        CloseConnection();
    }

    public static List<Booking> GetBookingByClientId(int client_id)
    {
        List<Booking> res = new List<Booking>();
        var query = "select Master.FirstName, Master.LastName, Service.Title, " +
                    "Service.ServiceCost, Booking.Datetime, Booking.BookingStatus, Booking.Id " +
                    "from Booking " +
                    "join Service on Booking.ServiceId = Service.Id " +
                    "join Master on Booking.MasterID = Master.Id " +
                    "where Booking.ClientId = " + client_id + ";";

        OpenConnection();
        var reader = new SqlCommand(query, connection).ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                res.Add(new Booking((string)reader[5], (string)reader[0], (string)reader[1], 
                                    (string)reader[2], (double)reader[3], (string)reader[4], (int)reader[6]));
            }
        }

        CloseConnection();
        return res;
    }

    public static void DeleteBookingByID(int id)
    {
        var query = "delete from Booking where id = " + id + ";";
        OpenConnection();
        new SqlCommand(query, connection).ExecuteNonQuery();
        CloseConnection();
    }

    public static void UpdateBookingStatus(int id, BookingStatus NewStatus)
    {
        var query = "update Booking set BookingStatus = N'{1}' where Id = {0};";
        OpenConnection();
        new SqlCommand(String.Format(query, id, NewStatus), connection).ExecuteNonQuery();
        CloseConnection();
    }

    public static bool isBookedOnDateOnMaster(string date, int master_id)
    {
        var query = "select * from booking where masterid = {0} " +
                    "and DateTime = N'{1}';";
        bool result = false;
        OpenConnection();

        var reader = new SqlCommand(String.Format(query, master_id, date), connection).ExecuteReader();
        if (reader.HasRows)
        {
            result = true;
        }
        else
        {
            result = false;
        }

        CloseConnection();

        return result;
    }



    private static void OpenConnection()
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
    }

    private static void CloseConnection()
    {
        if (connection.State != System.Data.ConnectionState.Closed)
            connection.Close();
    }


    // ИЗМЕНИ ПЕРЕД ТЕМ, КАК ЗАПУСКАТЬ
    private static SqlConnection connection = new SqlConnection(ConnectionString);

    public enum BookingStatus { BOOKED, PAYED, ATTENDED }

    public const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Project\\Spa\\Spa\\App_Data\\SpaDB.mdf;Integrated Security=True";
}