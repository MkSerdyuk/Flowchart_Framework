using Flowchart_Framework.ViewModels;
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
    /// Interaction logic for Connector.xaml
    /// </summary>
    public partial class Connector : UserControl
    {
        private LayoutWatcher _selfWatcher = new LayoutWatcher();
        private LayoutWatcher _fromWatcher = new LayoutWatcher();
        private LayoutWatcher _toWatcher = new LayoutWatcher();
     

        public FrameworkElement From
        {
            get { return (FrameworkElement)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly DependencyProperty FromProperty =
        DependencyProperty.Register("From", typeof(FrameworkElement), typeof(FrameworkElement),
        new FrameworkPropertyMetadata((o, args) =>
        { var self = (Connector)o; self._fromWatcher.ChangeTarget(self.From); }));

        public FrameworkElement To
        {
            get { return (FrameworkElement)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(FrameworkElement), typeof(FrameworkElement),
                new FrameworkPropertyMetadata((o, args) =>
                { var self = (Connector)o; self._toWatcher.ChangeTarget(self.To); }));

        public Connector()
        {
            InitializeComponent();

            _selfWatcher.ChangeTarget(this);
            _selfWatcher.Changed += RedrawLine;
            _fromWatcher.Changed += RedrawLine;
            _toWatcher.Changed += RedrawLine;
            RedrawLine(null, null);
        }

        private void RedrawLine(object sender, LayoutChangeEventArgs e)
        {    
            if (From == null || To == null)
            {
                ConnectingLine.Visibility = Visibility.Collapsed;
                return;
            }

            ConnectingLine.Visibility = Visibility.Visible;

            var fromRect = LayoutWatcher.ComputeRendererPoint(From, this);
            var toRect = LayoutWatcher.ComputeRendererPoint(To, this);

            ConnectingLine.X1 = fromRect.X + 10;
            ConnectingLine.Y1 = fromRect.Y + 10;

            ConnectingLine.X2 = toRect.X + 10;
            ConnectingLine.Y2 = toRect.Y + 10;
        }
    }
}
