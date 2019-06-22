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

namespace Demo05_03_InputBindings
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ICommand HelloCommand = new RoutedCommand("Hello", typeof(MainWindow));


        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("キーボードショートカットから起動されました");
        }

        private void CommandBinding_Executed_Button(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("ボタンが押されました");
        }

    }
}
