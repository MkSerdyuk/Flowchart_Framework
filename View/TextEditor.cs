using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flowchart_Framework.View
{
    public class TextEditor : Editor
    {
        private string _value;

        private TextBox _textBox = new TextBox();

        public string Value
        {
            get { return _value; }
            set 
            { 

                _value = value; 
                Out.Value = value + _textBox.Text;
            }
        }


        public TextEditor()
        {
            InitializeComponent();
            _textBox.TextChanged += TextChanged;

            _textBox.SetValue(Grid.ColumnProperty, 0);

            MainGrid.Children.Add(_textBox);
        }

        private void TextChanged(object sender, EventArgs e)
        {
            Out.Value = Value + _textBox.Text;
        }
    }
}
