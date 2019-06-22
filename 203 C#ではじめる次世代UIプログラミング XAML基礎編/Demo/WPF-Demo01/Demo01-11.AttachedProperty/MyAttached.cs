using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace AttachedProperty
{
    /// <summary>
    /// Grid を継承した MyGrid クラス
    /// 前提として2x2のグリッド
    /// </summary>
    class MyGrid : Grid
    {

        #region 添付プロパティ
        public static int GetPosition(DependencyObject obj)
        {
            return (int)obj.GetValue(PositionProperty);
        }

        public static void SetPosition(DependencyObject obj, int value)
        {
            obj.SetValue(PositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached(
                                "Position", 
                                typeof(int), 
                                typeof(MyGrid), 
                                new PropertyMetadata(
                                    0,                  //初期値
                                    OnPositionChanged   //値変更時のコールバック
                                    )
                                );

        /// <summary>
        /// 値が設定されたときには値変更のコールバックを使用する
        /// Position の値を元に、どのセルに配置するかを決める
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element == null) { return; }

            var setValue = GetPosition(element);
            
            switch (setValue % 4)
            {
                case 0:
                    SetRow(element, 0);
                    SetColumn(element, 0);
                    break;
                case 1:
                    SetRow(element, 1);
                    SetColumn(element, 0);
                    break;
                case 2:
                    SetRow(element, 0);
                    SetColumn(element, 1);
                    break;
                case 3:
                    SetRow(element, 1);
                    SetColumn(element, 1);
                    break;
                default:
                    break;
            }
        }

        #endregion 
    }
}
