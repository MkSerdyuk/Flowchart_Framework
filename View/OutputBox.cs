using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flowchart_Framework.View
{
    public class OutputBox : Block
    {
        public InPort Port = new InPort();

        public TextBox Out = new TextBox();

        public OutputBox()
        {
            InitializeComponent();

            Port.SetValue(Grid.RowProperty, 0);
            Port.SetValue(Grid.ColumnProperty, 1);

            Port.Parent = this;

            Out.IsEnabled = false;
            Out.SetValue(Grid.RowProperty, 1);
            Out.SetValue(Grid.ColumnProperty, 0);
            Out.SetValue(Grid.ColumnSpanProperty, 3);

            MainGrid.Children.Add(Port);
            MainGrid.Children.Add(Out); 
        }

        public override void InputChanged()
        {
            Out.Text = Port.Value;
        }
    }
}
