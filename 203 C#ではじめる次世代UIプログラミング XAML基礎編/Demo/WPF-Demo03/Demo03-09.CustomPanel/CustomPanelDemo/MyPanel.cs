using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using System.Diagnostics;
using System;

namespace CustomPanelDemo
{
    class MyPanel : Panel
    {
        public MyPanel() : base() 
        {
            
        }

        /// <summary>
        /// 測定処理
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Debug.Write("全体測定処理");
            Debug.WriteLine("{0}\t{1}", availableSize.Width, availableSize.Width);

            Size panelDesired = new Size();

            //子要素の要求サイズを取得する
            foreach (UIElement item in InternalChildren)
            {
                item.Measure(availableSize);

                Debug.Write("測定処理");
                Debug.WriteLine("{0}\t{1}",item.DesiredSize.Width,item.DesiredSize.Width);

                //各要素の要求サイズのうち最大の値を採用する
                if (item.DesiredSize.Width > panelDesired.Width) { panelDesired.Width = item.DesiredSize.Width; }
                if (item.DesiredSize.Height > panelDesired.Height) { panelDesired.Height = item.DesiredSize.Height; }

            }

            Debug.WriteLine("結果\t{0}\t{1}", panelDesired.Width, panelDesired.Height);

            return panelDesired;
            
        }

        /// <summary>
        /// 配置処理
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Debug.Write("全体配置処理");
            Debug.WriteLine("{0}\t{1}", finalSize.Width, finalSize.Height);

            foreach (UIElement item in InternalChildren)
            {
                int x = OffsetX;
                int y = OffsetY;

                //設定されたOffset 値を取得する
                int offsetValue = GetOffsetNumber(item);

                int resultX = x * (offsetValue + 1);
                int resultY = y * (offsetValue + 1);

                double resultWidth = item.DesiredSize.Width;
                double resultHeight = item.DesiredSize.Height;

                Control ctl = item as Control;
                if (ctl == null) { break; }

                //ここではコントロールが画面外にはみ出る場合に色を変更する
                //描画ポイントを変更するなどの処理を加えるのもアリ
                if (resultX + item.DesiredSize.Width > finalSize.Width)
                {
                    ctl.Background = Brushes.Red;
                }
                else if (resultY + item.DesiredSize.Height > finalSize.Height)
                {
                    ctl.Background = Brushes.LightGreen;
                }
                else
                {
                    ctl.Background = Brushes.LightGray;
                }

                Debug.Write("配置処理");
                Debug.WriteLine("{0}\t{1}", resultHeight, resultWidth);

                item.Arrange(new Rect(new Point(resultX, resultY), new Size(resultWidth,resultHeight)));
            }
            return finalSize;
        }

        #region 子要素に位置を決定させるための添付プロパティ
        public static int GetOffsetNumber(DependencyObject obj)
        {
            return (int)obj.GetValue(OffsetNumberProperty);
        }

        public static void SetOffsetNumber(DependencyObject obj, int value)
        {
            obj.SetValue(OffsetNumberProperty, value);
        }

        // Using a DependencyProperty as the backing store for OffsetNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetNumberProperty =
            DependencyProperty.RegisterAttached("OffsetNumber", typeof(int), typeof(MyPanel), new PropertyMetadata(0));
        #endregion 

        
        #region オフセット値を設定させるための依存関係プロパティ
        public int OffsetX
        {
            get { return (int)GetValue(OffsetXProperty); }
            set { SetValue(OffsetXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetXProperty =
            DependencyProperty.Register("OffsetX", typeof(int), typeof(MyPanel),
            new FrameworkPropertyMetadata(10,
                FrameworkPropertyMetadataOptions.AffectsMeasure
                )
            );

        public int OffsetY
        {
            get { return (int)GetValue(OffsetYProperty); }
            set { SetValue(OffsetYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetYProperty =
            DependencyProperty.Register("OffsetY", typeof(int), typeof(MyPanel),
            new FrameworkPropertyMetadata(10,
                FrameworkPropertyMetadataOptions.AffectsMeasure
                )
            );
        #endregion 
    }
}
