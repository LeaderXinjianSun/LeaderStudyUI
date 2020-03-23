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
using System.Windows.Shapes;

namespace LeaderStudyUI.Views
{
    /// <summary>
    /// SubWindow1.xaml 的交互逻辑
    /// </summary>
    public partial class SubWindow1 : Window
    {
        public SubWindow1()
        {
            InitializeComponent();
        }
        public bool HasShow { set; get; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }


        public bool QuitSubWindow1
        {
            get { return (bool)GetValue(QuitSubWindow1Property); }
            set { SetValue(QuitSubWindow1Property, value); }
        }

        // Using a DependencyProperty as the backing store for QuitSubWindow1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuitSubWindow1Property =
            DependencyProperty.Register("QuitSubWindow1", typeof(bool), typeof(SubWindow1), new PropertyMetadata(
                new PropertyChangedCallback((d, e) => {
                    var mSubWindow1 = d as SubWindow1;
                    if (mSubWindow1.HasShow)
                    {
                        mSubWindow1.HasShow = false;
                        mSubWindow1.Close();
                        mSubWindow1 = null;
                    }
                })));


    }
}
