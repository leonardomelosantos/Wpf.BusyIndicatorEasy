using System;
using System.Windows;

namespace Wpf.BusyIndicatorEasy.Core
{
    public class IndexChangedEventArgs : PropertyChangedEventArgs<int>
    {
        #region Constructors

        public IndexChangedEventArgs(RoutedEvent routedEvent, int oldIndex, int newIndex)
            : base(routedEvent, oldIndex, newIndex)
        {
        }

        #endregion

        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            ((IndexChangedEventHandler) genericHandler)(genericTarget, this);
        }
    }
}