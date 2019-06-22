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
//アニメーションはこの名前空間です
using System.Windows.Media.Animation;

namespace Demo03_03_Animation
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
        /// <summary>
        /// ボタンクリック処理でアニメーションを実行します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ターゲットのプロパティによって生成すべき型がかわります
            var myAnimation = new DoubleAnimation();
            //初期値を設定します
            myAnimation.From = 10;
            //終了値を設定します
            myAnimation.To = 150;
            //アニメーションの再生時間を設定します
            myAnimation.Duration = new TimeSpan(0, 0, 3);
            //アニメーションの再生回数を設定します
            myAnimation.RepeatBehavior = new RepeatBehavior(1);
            //対象となるコントロールに対してアニメーションの開始を指示します
            //第一引数に対象となる依存関係プロパティをせってします
            //第二引数にアニメーションの定義を設定します
            this.txtDisplay.BeginAnimation(TextBlock.FontSizeProperty, myAnimation);
        }
    }
}
