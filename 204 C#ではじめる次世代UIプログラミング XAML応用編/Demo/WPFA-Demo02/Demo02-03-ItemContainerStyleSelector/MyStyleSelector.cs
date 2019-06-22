using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//StyleSelector は System.Windows.Controls に含まれます
using System.Windows.Controls;
//Style は System.Windows に含まれます
using System.Windows;
//Brush は System.Windows.Media に含まれます
using System.Windows.Media;

namespace Demo02_03_ItemContainerStyleSelector
{
    class MyStyleSelector : StyleSelector
    {
        /// <summary>
        /// Styleを返却します
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns>生成されたStyle</returns>
        public override Style SelectStyle(object item, DependencyObject container)
        {
            //返却するStyleを生成します
            var myStyle = new Style();
            //対象となるTypeを設定します。ここではListBoxItemを設定します。
            myStyle.TargetType = typeof(ListBoxItem);
            //Styleを設定するためのSetterを作成します
            var backGroundSetter = new Setter();
            var foreGroundSetter = new Setter();

            //Setterで設定する先の依存関係プロパティを設定します
            backGroundSetter.Property = ListBoxItem.BackgroundProperty;
            foreGroundSetter.Property = ListBoxItem.ForegroundProperty;

            //作成したStyleの設定先です
            //現実的なコードでは型チェックをした方が良いでしょう
            var target = (ListBoxItem)container;

            //データの内容によって背景色を変更します
            if (target.DataContext.ToString() == "Test 5")
            {
                backGroundSetter.Value = Brushes.Navy;
                foreGroundSetter.Value = Brushes.White;
            }
            else
            {
                backGroundSetter.Value = Brushes.PaleGreen;
                foreGroundSetter.Value = Brushes.Yellow;
            }
            //背景色を設定したSetterをStyleに追加します
            myStyle.Setters.Add(backGroundSetter);
            myStyle.Setters.Add(foreGroundSetter);

            //作成されたStyleを返却します
            return myStyle;
        }

    }
}
