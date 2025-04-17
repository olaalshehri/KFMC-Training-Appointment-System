using KFCproject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace KFCproject.demo
{
    public partial class DataLogging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateDdlcountry();
                populateDdlGender();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void populateDdlGender()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"Select genderId ,gender from gender";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlgender.DataValueField = "genderId";
            ddlgender.DataTextField = "gender";
            ddlgender.DataSource = dr;
            ddlgender.DataBind();
           
        }
        protected void populateDdlcountry()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"Select countryId ,country from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlcountry.DataValueField = "countryId";
            ddlcountry.DataTextField = "country";
            ddlcountry.DataSource = dr;
            ddlcountry.DataBind();

        }

        public static void ExportGridToExcel(GridView myGv) // working 1
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "ExportedReport_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            myGv.GridLines = GridLines.Both;
            myGv.HeaderStyle.Font.Bold = true;
            myGv.RenderControl(htmltextwrtter);
        }


        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvcontact);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            getData();
        }
        protected void getData()
        {
            // I write the logic code to get data from db
            CRUD myCrud = new CRUD();
            string mySql = @"select LoginId,fName,age,phone,l.genderid,g.gender,l.countryid,c.country
                    from Loginuser l inner join country c on l.countryid = c.countryId inner join gender g on l.genderid = g.genderId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvcontact.DataSource = dr;
            gvcontact.DataBind();
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            // write code to make data validation 
            if (String.IsNullOrEmpty(txtage.Text))
            {
                lblOutput.Text = "Please fill age field!";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                txtage.Focus();
                return;
            }


            CRUD myCrud = new CRUD();
                string mySql = @" insert Loginuser(fName,age,phone,genderid,countryid)
                             values(@fName,@age,@phone,@genderid,@countryid)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();

            
            myPara.Add("@fName", txtfname.Text);
            myPara.Add("@age", txtage.Text);
            myPara.Add("@phone", txtphone.Text);
            myPara.Add("@genderid", ddlgender.SelectedValue);
            myPara.Add("@countryid", ddlcountry.SelectedValue);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                {
                    lblOutput.Text = "Operation Successful!";
                }
                else
                {
                    lblOutput.Text = "Operation Failed!";
                }
                getData();
            
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @" update Loginuser set  fName=@fName,age=@age ,phone=@phone ,genderid=@genderid ,countryid=@countryid
                                where LoginId = @LoginId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@LoginId", txtId.Text);
            myPara.Add("@fName", txtfname.Text);
            myPara.Add("@age", txtage.Text);
            myPara.Add("@phone", txtphone.Text);
            myPara.Add("@genderid", ddlgender.SelectedValue);
            myPara.Add("@countryid", ddlcountry.SelectedValue);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successfull!"; }
            else
            { lblOutput.Text = "Operation Failed"; }
            getData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"delete Loginuser 
                                where LoginId = @LoginId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@LoginId", int.Parse(txtId.Text));
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successfull!"; }
            else
            { lblOutput.Text = "Operation Failed"; }
            getData();
        }

        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"  select LoginId,fName,age,phone,genderid,countryid
                        from Loginuser where LoginId = @LoginId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@LoginId", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String loginId = dr["LoginId"].ToString();
                        String fName = dr["fName"].ToString();
                       
                        String countryId = dr["countryId"].ToString();
                        String phone = dr["phone"].ToString();
                        String Age = dr["Age"].ToString();
                        String genderId = dr["genderId"].ToString();
                        //lblOuput.Text = empId + employee+ depId;
                        txtId.Text = loginId;
                        txtfname.Text = fName;

                        txtage.Text = dr["Age"].ToString();
                        ddlgender.SelectedValue = genderId;
                        ddlcountry.SelectedValue = countryId;
                        txtphone.Text = dr["phone"].ToString();
                       
                    }
                }
            }
        }


    }//cs
    
}//ns
