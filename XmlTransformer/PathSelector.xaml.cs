using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace XmlTransformer
{
    /// <summary>
    /// PathSelector.xaml 的交互逻辑
    /// </summary>
    public partial class PathSelector : UserControl
    {
        public PathSelector()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog();
            if (dialogResult.HasValue)
            {
                if (dialogResult.Value)
                {
                    this.Path = dialog.FileName;
                }
            }
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(PathSelector), new PropertyMetadata(""));


    }
}
