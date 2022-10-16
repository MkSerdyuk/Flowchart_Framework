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
        private Connector _target, _origin;
        private Rect _currentRendererRect = Rect.Empty;
        public event EventHandler<LayoutChangeEventArgs> Changed;

        public void ChangeTarget(Connector target, Connector origin = null)
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

        public static Rect ComputeRendererRect(Connector target, Connector origin)
        {
            return new Rect(target.TranslatePoint(new Point(), origin), target.RenderSize);
        }

        private Rect GetRendererRect()
        {
            return ComputeRendererRect(_target, _origin);
        }

    }
}
