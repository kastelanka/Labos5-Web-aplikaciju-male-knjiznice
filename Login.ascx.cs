using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace labos5
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //provjera korisnika, privatna metoda:
        private bool CheckUserNamePassword()
        {
            //klasa za citanje XMLova:
            XElement korisnici = XElement.Load(@"C:\Users\AnaLo\source\repos\labos5\App_Data\korisnici.xml");//relative pathove!!
            var users = from user in korisnici.Elements("korisnik") 
                select new
                {
                    username = (String)user.Element("korisnickoIme"),
                    password = (String)user.Element("lozinka")
                };

            foreach (var user in users)
            {
                //if (user.username == TextBoxUsername.Text) && (user.password == TextBoxPassword.Text))
                if((string.Compare(user.username, TextBoxUsername.Text, true) == 0)
                && ((user.password == TextBoxPassword.Text)))
                {
                    return true;
                }
            }

            return false;
        }

        private void DisplayBooks()
        {
            PanelDisplay.Visible = true;
            using (DataSet ds = new  DataSet())
            {
                ds.ReadXml(@"C:\Users\AnaLo\source\repos\labos5\App_Data\popisKnjiga.xml");
                GridViewData.DataSource = ds;
                GridViewData.DataBind();
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            //1. je li postoji taj username i password:
            if (!CheckUserNamePassword())
            {
                PanelError.Visible = true;
            }
            else
            {
                DisplayBooks();

            }
        }
    }
}