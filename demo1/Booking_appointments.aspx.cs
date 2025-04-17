using KFCproject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KFCproject.demo1
{
    public partial class Booking_appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateDdlservicena();
                populateDdldoctor();
                
            }
        }

        protected void populateDdlservicena()
        {
            CRUD myCrud = new CRUD();
            string mySql = @" select serviceId,servicename from servicena";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlservicename.DataValueField = "serviceId";
            ddlservicename.DataTextField = "servicename";
            ddlservicename.DataSource = dr;
            ddlservicename.DataBind();

        }

        protected void populateDdldoctor()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select doctorId,doctorname from doctor";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddldoctorname.DataValueField = "doctorId";
            ddldoctorname.DataTextField = "doctorname";
            ddldoctorname.DataSource = dr;
            ddldoctorname.DataBind();

        }
       
       
        protected void btnsend_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert Booking_appointments (FileNo,firstname,middlename,lastname,NationalID,phonenumber,eamil,dateday,time)
                values (@FileNo,@firstname,@middlename,@lastname,@NationalID,@phonenumber,@eamil,@dateday,@time)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@FileNo", txtfileno.Text);
            myPara.Add("@firstname", txtfirstname.Text);
            myPara.Add("@middlename", txtmiddlename.Text);
            myPara.Add("@lastname", txtlastname.Text);
            myPara.Add("@NationalID", txtnationalID.Text);
            myPara.Add("@phonenumber", txtphonenumber.Text);
            myPara.Add("@eamil", txteamil.Text);
            myPara.Add("@dateday", txtdateday.Text);
            myPara.Add("@time", txttime.Text);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Success !"; }
            else
            { lblOutput.Text = "Operation Failed !"; }

            
        }

        protected void ddlservicename_SelectedIndexChanged(object sender, EventArgs e)
        {

                CRUD myCrud = new CRUD();
                string mySql = @"select doctorId,doctorname from doctor where serviceId = @serviceId ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@serviceId", ddlservicename.SelectedItem.Value);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                ddldoctorname.DataValueField = "doctorId";
                ddldoctorname.DataTextField = "doctorname";
                ddldoctorname.DataSource = dr;
                ddldoctorname.DataBind();

        }
    }
}