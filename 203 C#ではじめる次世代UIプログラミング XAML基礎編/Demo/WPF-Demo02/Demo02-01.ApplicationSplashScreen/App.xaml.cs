using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Demo02_01.ApplicationSplashScreen
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region スプラッシュスクリーンを手動で表示
            //var splashScreen = new SplashScreen("splashimage.jpg");
            //splashScreen.Show(false);
            //splashScreen.Close(new TimeSpan(0, 0, 3));
            #endregion
        }
    }
}
