using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleRpWebApp
{
    public partial class CleanUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/", false);
            }
            else
            {
                this.Session.Abandon();
                var signOutImage = new byte[]
                                   {
                                       71, 73, 70, 56, 57, 97, 17, 0, 13, 0, 162, 0, 0, 255, 255, 255, 
                                       169, 240, 169, 125, 232, 125, 82, 224, 82, 38, 216, 38, 0, 0, 0, 0, 
                                       0, 0, 0, 0, 0, 33, 249, 4, 5, 0, 0, 5, 0, 44, 0, 0, 
                                       0, 0, 17, 0, 13, 0, 0, 8, 84, 0, 11, 8, 28, 72, 112, 32, 
                                       128, 131, 5, 19, 22, 56, 24, 128, 64, 0, 0, 10, 13, 54, 116, 8, 
                                       49, 226, 193, 1, 4, 6, 32, 36, 88, 113, 97, 0, 140, 26, 11, 30, 
                                       68, 8, 64, 0, 129, 140, 29, 5, 2, 56, 73, 209, 36, 202, 132, 37, 
                                       79, 14, 112, 73, 81, 97, 76, 150, 53, 109, 210, 36, 32, 32, 37, 76, 
                                       151, 33, 35, 26, 20, 16, 84, 168, 65, 159, 9, 3, 2, 0, 59
                                   };

                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.ClearContent();
                this.Response.ContentType = "image/gif";
                this.Response.BinaryWrite(signOutImage);
            }
        }
    }
}