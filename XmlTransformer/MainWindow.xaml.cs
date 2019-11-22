using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace XmlTransformer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnApplyTransform_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(xmlSelector.Path) && File.Exists(xsltSelector.Path))
            {
                string xmlFilePath = xmlSelector.Path;
                string xsltPath = xsltSelector.Path;
                XPathDocument doc = new XPathDocument(xmlFilePath);
                XslCompiledTransform trans = new XslCompiledTransform();
                trans.Load(xsltPath);
                using (XmlTextWriter writer = new XmlTextWriter(htmlSelector.Path, null))
                {
                    trans.Transform(doc, null, writer);
                };           
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Please fill the three paths and ensure xml and xslt file exist!");
            }
        }
    }
}
