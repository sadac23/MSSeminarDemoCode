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

namespace Demo04_06.DataFlow
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

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person) this.Resources["PersonData"];
            string data = string.Format("Name = [{0}]\nAddress=[{1}]", p.Name, p.Address);

            MessageBox.Show(data);
        }

        private void ResetDataButton_Click(object sender, RoutedEventArgs e)
        {
            Person p    = (Person)this.Resources["PersonData"];
            p.Name      = "舞黒　太郎";
            p.Address   = "東京都千代田区大手町１－１－３";
        }
    }
}
