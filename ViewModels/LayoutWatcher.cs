using Flowchart_Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flowchart_Framework.ViewModels
{
    public class LayoutChangeEventArgs : EventArgs
    {
        public readonly Point Point;
        public LayoutChangeEventArgs(Point Point) => Point = Point;
    }
    
    public class LayoutWatcher
    {
        private FrameworkElement _target, _origin;
        private Point _currentRendererPoint;
        public event EventHandler<LayoutChangeEventArgs> Changed;

        public void ChangeTarget(FrameworkElement target, FrameworkElement origin = null)
        {
            if (_target != null)
            {
                _target.LayoutUpdated -= OnLayoutUpdate;
            }

            _target = target;
            _origin = origin;
            OnLayoutUpdate(null, null);

            if (_target != null)
            {
                _target.LayoutUpdated += OnLayoutUpdate;
            }
        } 

        private void OnLayoutUpdate(object sender, EventArgs e)
        {
            Point newRendererPoint = GetRendererPoint();
            if (newRendererPoint != _currentRendererPoint)
            {
                _currentRendererPoint = newRendererPoint;
                Changed?.Invoke(_target, new LayoutChangeEventArgs(_currentRendererPoint));
            }
        }

        public static Point ComputeRendererPoint(FrameworkElement target, FrameworkElement origin)
        {
            return target.TranslatePoint(new Point(), origin);
        }

        private Point GetRendererPoint()
        {
            return ComputeRendererPoint(_target, _origin);
        }

    }
}
