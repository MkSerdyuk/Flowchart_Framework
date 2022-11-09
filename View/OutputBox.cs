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

            Port.SetValue(Grid.RowProperty, 1);
            Port.SetValue(Grid.ColumnProperty, 0);

            Port.Parent = this;

            Out.IsEnabled = false;
            Out.SetValue(Grid.RowProperty, 2);
            Out.SetValue(Grid.ColumnProperty, 0);
            Out.SetValue(Grid.ColumnSpanProperty, 3);

            Label label = new Label();

            label.Content = "Output Block";
            label.SetValue(Grid.RowProperty, 0);
            label.SetValue(Grid.ColumnProperty, 0);
            label.SetValue(Grid.ColumnSpanProperty, 3);

            MainGrid.Children.Add(Port);
            MainGrid.Children.Add(Out); 
            MainGrid.Children.Add(label);
        }

        public override void InputChanged()
        {
            Out.Text = Port.Value;
        }
    }
}
