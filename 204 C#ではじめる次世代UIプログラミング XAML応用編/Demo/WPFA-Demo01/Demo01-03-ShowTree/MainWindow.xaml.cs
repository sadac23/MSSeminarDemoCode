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

namespace ShowTree
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
        /// スタックレベル
        /// </summary>
        int intStackLevel = 0;

        /// <summary>
        /// Visual Tree 表示ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearSituation();
            EnumVisual(this);
        }

        /// <summary>
        /// Visual Tree の列挙を行う
        /// </summary>
        /// <param name="myVisual">列挙対象のオブジェクト</param>
        /// <remarks>含まれる子要素が無くなるまで再帰処理を行う</remarks>
        private void EnumVisual(Visual myVisual)
        {
            intStackLevel++;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.
                this.txtOutput.Text += GetFillerString() + childVisual.GetType().FullName + "\n";

                // Enumerate children of the child visual object.
                EnumVisual(childVisual);

                intStackLevel--;
            }
        }

        /// <summary>
        /// スタックレベルを表示するための編集
        /// </summary>
        /// <returns></returns>
        private string GetFillerString()
        {
            string filler = string.Empty;
            for (int j = 0; j < intStackLevel; j++)
            {
                filler += "-";
            }
            return filler;
        }

        /// <summary>
        /// 論理ツリー表示ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClearSituation();
            EnumLogical(this);
        }

        /// <summary>
        /// 論理ツリーの列挙
        /// </summary>
        /// <param name="myElement">列挙対象のオブジェクト</param>
        /// <remarks>含まれる子要素が無くなるまで再帰処理を行う</remarks>
        private void EnumLogical(DependencyObject myElement)
        {
            intStackLevel++;
            if (intStackLevel > 3) { return; }

            foreach (var item in LogicalTreeHelper.GetChildren(myElement))
            {
                this.txtOutput.Text += GetFillerString() + item.GetType().FullName + "\n";

                if (item is DependencyObject)
                {
                    EnumLogical((DependencyObject)item);
                }
                intStackLevel--;
            }
        }

        /// <summary>
        /// 情況の初期化処理
        /// テキストのクリアとスタックレベルの初期化
        /// </summary>
        private void ClearSituation()
        {
            this.txtOutput.Text = string.Empty;
            intStackLevel = 0;
        }

    }
}
