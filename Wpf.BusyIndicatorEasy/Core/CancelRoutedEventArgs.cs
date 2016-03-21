﻿using System.Windows;

namespace Wpf.BusyIndicatorEasy.Core
{
    public delegate void CancelRoutedEventHandler(object sender, CancelRoutedEventArgs e);

    /// <summary>
    ///     An event data class that allows to inform the sender that the handler wants to cancel
    ///     the ongoing action.
    ///     The handler can set the "Cancel" property to false to cancel the action.
    /// </summary>
    public class CancelRoutedEventArgs : RoutedEventArgs
    {
        public CancelRoutedEventArgs()
            : base()
        {
        }

        public CancelRoutedEventArgs(RoutedEvent routedEvent)
            : base(routedEvent)
        {
        }

        public CancelRoutedEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        {
        }

        #region Cancel Property

        public bool Cancel { get; set; }

        #endregion Cancel Property
    }
}