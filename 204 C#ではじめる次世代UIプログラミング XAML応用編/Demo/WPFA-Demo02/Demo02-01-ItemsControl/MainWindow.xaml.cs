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

namespace Demo02_01_ItemsControl
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region 例１：単純な文字列配列
            string[] data = {
                                "東京",
                                "有楽町",
                                "新橋",
                                "浜松町",
                                "田町",
                                "品川"
                            };
            this.myListBox.ItemsSource = data;
            #endregion

            #region 例２：任意のエンティティクラス
            Station[] stations = {
                                     new Station{Name="東京"},
                                     new Station{Name="有楽町"},
                                     new Station{Name="新橋"},
                                     new Station{Name="浜松町"},
                                     new Station{Name="田町"},
                                     new Station{Name="品川"}
                                 };
            this.mySecondListBox.ItemsSource = stations;
            #endregion


        }
    }

    internal class Station
    {
        public string Name { get; set; }

        #region 正しく表示するには
        //public override string ToString()
        //{
        //    return Name;
        //}
        #endregion 
    }
}
