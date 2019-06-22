using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo01_05.RoutingEvent
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MyMouseDown(object sender, MouseButtonEventArgs e)
        {
            string message = string.Format("(MouseDown) {0}", sender.ToString());
            Console.WriteLine(message);
        }

        private void MyPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string message = string.Format("[PreviewMouseDown] {0}", sender.ToString());
            Console.WriteLine(message);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyMouseDown(sender, e);
        }

        private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyMouseDown(sender, e);
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyMouseDown(sender, e);
        }

        private void Window_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyPreviewMouseDown(sender, e);
        }

        private void StackPanel_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyPreviewMouseDown(sender, e);
        }

        private void Button_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyPreviewMouseDown(sender, e);
        }
    }
}
