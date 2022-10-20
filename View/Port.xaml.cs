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

namespace Flowchart_Framework.View
{
    /// <summary>
    /// Interaction logic for Port.xaml
    /// </summary>
    public partial class Port : UserControl
    {
        public Port()
        {
            InitializeComponent();
        }

        private static Port _from;
        private static Port _to;



        private void Port_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_from == null)
            {
                _from = this;
            }
            else
            {
                _to = this;
                Connector connector = new Connector(_from, _to);
                _from = null;
                _to = null;
                Grid.Children.Add(connector);
            }


        }
    }
}
