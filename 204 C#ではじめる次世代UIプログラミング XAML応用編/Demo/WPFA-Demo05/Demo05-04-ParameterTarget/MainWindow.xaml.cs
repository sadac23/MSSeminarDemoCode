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

namespace Demo05_04_ParameterTarget
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ICommand PutHelloCommand = new RoutedCommand();
        public static ICommand PutWPFCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void CommandBinding_PutHelloExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            textBox1.Text += (string)e.Parameter;
        }

        private void CommandBinding_PutWPFExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var target = (TextBox)e.Source;
            target.Text += " WPF ";
        }

    }
}
