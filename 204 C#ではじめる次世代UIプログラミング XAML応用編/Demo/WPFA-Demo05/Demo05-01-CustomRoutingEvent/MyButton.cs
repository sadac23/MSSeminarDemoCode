using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Demo05_01_CustomRoutingEvent
{
    public class MyButton : Button
    {
        public static readonly RoutedEvent TapEvent =
            EventManager.RegisterRoutedEvent(
                "Tap",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(MyButton));

        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        protected override void OnClick()
        {
            var e = new RoutedEventArgs(MyButton.TapEvent);
            RaiseEvent(e);

            base.OnClick();
        }
    }
}
