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
        public readonly Rect Rect;
        public LayoutChangeEventArgs(Rect Rect) => Rect = Rect;
    }
    
    public class LayoutWatcher
    {
        private FrameworkElement _target, _origin;
        private Rect _currentRendererRect = Rect.Empty;
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
            Rect newRendererRect = GetRendererRect();
            if (newRendererRect != _currentRendererRect)
            {
                _currentRendererRect = newRendererRect;
                Changed?.Invoke(_target, new LayoutChangeEventArgs(_currentRendererRect));
            }
        }

        public static Rect ComputeRendererRect(FrameworkElement target, FrameworkElement origin)
        {
            return new Rect(target.TranslatePoint(new Point(), origin), target.RenderSize);
        }

        private Rect GetRendererRect()
        {
            return ComputeRendererRect(_target, _origin);
        }

    }
}
