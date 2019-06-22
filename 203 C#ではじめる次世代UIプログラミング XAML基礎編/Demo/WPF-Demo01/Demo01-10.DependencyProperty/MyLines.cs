
using System.Windows;
using System.Windows.Markup;

namespace DependencyPropertyDemo 
{
    [ContentProperty("LineNumber")]
    public class MyLines : DependencyObject
    {
        #region constructor
        public MyLines()
        {
            #region CLRプロパティを使用する場合：初期化
            this.MinValue = 0;
            this.MaxValue = 100;
            #endregion
        }
        #endregion

        #region LineNumber Property
        public int LineNumber
        {
            get { return (int)GetValue(LineNumberProperty); }
            set { SetValue(LineNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineNumberProperty =
            DependencyProperty.Register(
                "LineNumber",
                typeof(int),
                typeof(MyLines),
                new FrameworkPropertyMetadata(
                    0,                                                  //初期値
                    FrameworkPropertyMetadataOptions.None,              //描画などに影響がある場合など指定
                    new PropertyChangedCallback(OnLineNumberChanged),   //値変更時のコールバックを指定
                    new CoerceValueCallback(CoerceLineNumber)           //値強制のコールバックを指定
                    ),
                new ValidateValueCallback(IsValidLineNumber)            //値評価のコールバックを指定
                );

        /// <summary>
        /// 値変更時のコールバック
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnLineNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Changed!");
        }

        /// <summary>
        /// 値強制のコールバック
        /// MaxValue, MinValue の範囲に値を強制する
        /// (Null or 変換失敗 => 0)
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object CoerceLineNumber(DependencyObject d, object value)
        {
            var dd = (MyLines)d;

            int? inputValue = value as int?;
            if (inputValue.HasValue == false || inputValue.Value < dd.MinValue )
            {
                return 0;
            }
            else if(inputValue.Value > dd.MaxValue)
            {
                return dd.MaxValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 値チェックのコールバック
        /// false を返した時の動作に注目されたい
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidLineNumber(object value)
        {
            return true;
            #region 値チェックを有効にするのはこの部分
            ///値チェックを有効にした場合の動作にご注意ください
            //int? inputValue = value as int?;
            //if (inputValue.HasValue == false || inputValue.Value < 0 )
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            #endregion 

        }
        #endregion

        #region MinValue and MaxValue
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        #endregion
        
    }
}
