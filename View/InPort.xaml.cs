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
    /// Interaction logic for InPort.xaml
    /// </summary>
    public partial class InPort : UserControl
    {
        private string _value;

        public Block Parent;

//public EventHandler<>;

        public string Value
        {
            get { return _value; }
            set 
            { 

                _value = value;
                Parent.InputChanged();
            }
        }


        private OutPort _source;


        public InPort()
        {
            InitializeComponent();
        }

        private void Port_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PortManager.From != null)
            {
                ((Ellipse)PortManager.From.Grid.Children[0]).Fill = Brushes.White;
                PortManager.To = this;
                Connector connector = new Connector(PortManager.From, PortManager.To);
                Connector crunch = new Connector(PortManager.From, PortManager.To); //англ костыль
                PortManager.To._source = PortManager.From;
                PortManager.From.Grid.Children.Add(crunch);
                PortManager.From.Linked.Add(this);
                PortManager.From = null;
                PortManager.To = null;
                Grid.Children.Add(connector);
            }

        }

    }
}
