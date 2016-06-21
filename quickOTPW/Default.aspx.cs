using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

namespace quickOTPW
{
    public partial class _Default : Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtInput.TextChanged += new EventHandler(this.txtInput_TextChange);
            txtInput.Focus();
        }

        protected void txtInput_TextChange(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(lookUpPassword));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }

        void lookUpPassword()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtInput.Text, "\\d{3}"))
            {
                lblMessage.Text = "Input must be 3 digits between 000 and 999";
                txtInput.Text = "";
                txtInput.Focus();
                return;
            }

            lblMessage.Text = "searching...";

            XmlDocument xmlDoc = new XmlDocument();


            switch (dropVersion.Text)
            {
                case "Oxygen":
                    xmlDoc.Load(Server.MapPath("oxygen.xml"));
                    break;
                case "Nitrogen":
                    xmlDoc.Load(Server.MapPath("nitrogen.xml"));
                    break;
                case "Carbon":
                    xmlDoc.Load(Server.MapPath("carbon.xml"));
                    break;
            }

            lblMessage.Text = "Loaded xml...";

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//passwords/otpw");
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode numNode = itemNode.SelectSingleNode("num");
                XmlNode passwordNode = itemNode.SelectSingleNode("password");
                if ((numNode != null) && (passwordNode != null))
                { 
                    if (numNode.InnerText.Trim() == txtInput.Text.Trim())
                    {
                        string msg = "SF" + passwordNode.InnerText;
                        System.Windows.Forms.Clipboard.Clear();
                        System.Windows.Forms.Clipboard.SetText(msg);
                        //txtCopy.Text = msg;
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>document.getElementById('txtCopy').select();document.execCommand('copy');</script>", false);
                        lblMessage.Text = "The password: >" + msg + "< has been copied to your clipboard";
                    }
                }
            }
        }
    }
}