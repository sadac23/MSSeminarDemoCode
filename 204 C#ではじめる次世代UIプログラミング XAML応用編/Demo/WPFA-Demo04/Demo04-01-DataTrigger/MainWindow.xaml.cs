using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Demo04_01_DataTrigger
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MyStations stations = new MyStations();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stations.Add(new MyStation() { ID = 1, Name = "代々木上原" });
            stations.Add(new MyStation() { ID = 2, Name = "代々木公園" });
            stations.Add(new MyStation() { ID = 3, Name = "明治神宮前" });
            stations.Add(new MyStation() { ID = 4, Name = "表参道" });
            stations.Add(new MyStation() { ID = 5, Name = "乃木坂" });
            stations.Add(new MyStation() { ID = 6, Name = "赤坂" });
            stations.Add(new MyStation() { ID = 7, Name = "国会議事堂前" });
            stations.Add(new MyStation() { ID = 8, Name = "霞ヶ関" });
            stations.Add(new MyStation() { ID = 9, Name = "日比谷" });
            stations.Add(new MyStation() { ID = 10, Name = "二重橋前" });
            stations.Add(new MyStation() { ID = 11, Name = "大手町" });
            stations.Add(new MyStation() { ID = 12, Name = "新御茶ノ水" });
            stations.Add(new MyStation() { ID = 13, Name = "湯島" });
            stations.Add(new MyStation() { ID = 14, Name = "根津" });
            stations.Add(new MyStation() { ID = 15, Name = "千駄木" });
            stations.Add(new MyStation() { ID = 16, Name = "西日暮里" });
            stations.Add(new MyStation() { ID = 17, Name = "町屋" });
            stations.Add(new MyStation() { ID = 18, Name = "北千住" });
            stations.Add(new MyStation() { ID = 19, Name = "綾瀬" });
            stations.Add(new MyStation() { ID = 20, Name = "北綾瀬" });

            this.DataContext = stations;
        }
    }
}
