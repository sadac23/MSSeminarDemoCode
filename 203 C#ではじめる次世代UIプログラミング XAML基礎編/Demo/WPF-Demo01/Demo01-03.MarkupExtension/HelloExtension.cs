using System;
using System.Windows.Markup;

namespace Demo01_03.MarkupExtension
{
    public class HelloExtension : System.Windows.Markup.MarkupExtension
    {
        #region プロパティ
        public string Target { get; set; }
        #endregion

        #region コンストラクタ
        public HelloExtension()
        {
            Target = "WPF";
        }

        public HelloExtension(string target)
        {
            Target = target;
        }
        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return "Hello " + Target;
        }
    }
}
