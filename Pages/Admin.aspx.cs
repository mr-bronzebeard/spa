using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddMasterButton_Click(object sender, EventArgs e)
    {
        // IMAGE
        HttpPostedFile postedFile = MasterImage.PostedFile;
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = postedFile.ContentLength;
        Stream stream = postedFile.InputStream;
        BinaryReader binary = new BinaryReader(stream);
        byte[] picture = binary.ReadBytes((int)stream.Length);

        Model.AddMaster(masterFirstName.Text, masterLastName.Text, Info.Text, picture);
        Response.Write("<script>alert('OK!')</script>");
    }

    protected void AddServiceButton_Click(object sender, EventArgs e)
    {
        // IMAGE
        HttpPostedFile postedFile = ServiceImage.PostedFile;
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = postedFile.ContentLength;
        Stream stream = postedFile.InputStream;
        BinaryReader binary = new BinaryReader(stream);
        byte[] picture = binary.ReadBytes((int)stream.Length);

        double c = 0;
        try
        {
            c = Double.Parse(serviceCost.Text);
        }
        catch
        {
            Response.Write("<script>alert('NE NADO TAK VVODIT CHISLA!')</script>");
            return;
        }

        Model.AddService(serviceTitle.Text, serviceDescription.Text, c, picture);
        Response.Write("<script>alert('OK!')</script>");
    }

    protected void AddMasterServiceButton_Click(object sender, EventArgs e)
    {
        int service_id = Int32.Parse(Service.SelectedValue);
        int master_id = Int32.Parse(Master.SelectedValue);
        Model.AddMasterServiceRelation(master_id, service_id);
        Response.Write("<script>alert('OK!')</script>");
    }
}