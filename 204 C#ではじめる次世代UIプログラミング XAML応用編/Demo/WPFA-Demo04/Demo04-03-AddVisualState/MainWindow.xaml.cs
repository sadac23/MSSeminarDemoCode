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

namespace Demo04_03_AddVisualState
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

        private bool _IsTouched = true;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this.btnTouch, _IsTouched ? "Touched" : "UnTouched", true);
            if (_IsTouched) { _IsTouched = false; } else { _IsTouched = true; }
        }
    }
}
