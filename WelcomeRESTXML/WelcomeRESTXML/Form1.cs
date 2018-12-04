using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WelcomeRESTXML
{
    public partial class WelcomeRESTXML : Form
    {
        private HttpClient client = new HttpClient();

        private XNamespace xmlNamespace = XNamespace.Get(
            "http://schemas.microsoft.com/2003/10/Serialization/");

        public WelcomeRESTXML()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = await client.GetStringAsync(new Uri(
                "http://localhost:56021/WelcomeRESTXMLService.svc/welcome/" +
                txtName.Text));

            XDocument xmlResponse = XDocument.Parse(result);

            MessageBox.Show(xmlResponse.Element(
                xmlNamespace + "string").Value, "Welcome");
        }
    }
}
