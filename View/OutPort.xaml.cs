using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class OutPort : UserControl
    {

        private string _value;
        private string _editorValue;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (Linked != null)
                {
                    foreach(InPort linked in Linked)
                    {
                        linked.Value = _value + Command.Replace("{val}", _editorValue) + Endl ;
                    }
                }
            }
        }        
        
        public string EditorValue
        {
            get { return _value; }
            set
            {
                _editorValue = value;
                if (Linked != null)
                {
                    foreach(InPort linked in Linked)
                    {
                        linked.Value = _value + Command.Replace("{val}", _editorValue) + Endl ;
                    }
                }
            }
        }

        public List<string> EditorValueList
        {
            set
            {
                if (Linked != null)
                {
                    foreach (InPort linked in Linked)
                    {
                        var regex = new Regex(Regex.Escape("{val}"));
                        string temp = regex.Replace(Command, value[0], 1);
                        temp = regex.Replace(temp, value[1], 1);
                        linked.Value = _value + temp + Endl;
                    }
                }
            }
        }

        public List<InPort> Linked = new List<InPort>();

        public string Endl = "\n";
        public string Command = "";

        public void UpdateOut()
        {
            foreach (InPort linked in Linked)
            {
                linked.Value = _value + Command.Replace("{val}", _editorValue) + Endl;
            }
        }

        public OutPort()
        {
            InitializeComponent();
        }

        private void Port_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PortManager.From == null )
            {
                PortManager.From = this;
                ((Ellipse)PortManager.From.Grid.Children[0]).Fill = Brushes.Aqua;
            }

        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach(InPort linked in Linked.ToList<InPort>())
            {
                Linked.Remove(linked);
            }
            
            Grid.Children.RemoveRange(1, Grid.Children.Count-1);
        }
    }
}
