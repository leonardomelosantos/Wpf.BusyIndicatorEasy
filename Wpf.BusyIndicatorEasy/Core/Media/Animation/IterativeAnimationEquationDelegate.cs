using System;

namespace Wpf.BusyIndicatorEasy.Media.Animation
{
    public delegate T IterativeAnimationEquationDelegate<T>(TimeSpan currentTime, T from, T to, TimeSpan duration);
}