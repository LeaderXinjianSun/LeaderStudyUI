using LeaderStudyUI.ViewModels;
using LeaderStudyUI.Views;
using MahApps.Metro.Controls;
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

namespace LeaderStudyUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            this.SetBinding(ShowSubWindow1Property, "ShowSubWindow1");
        }


        public static SubWindow1 SubWindow1 = null;
        public bool ShowSubWindow1
        {
            get { return (bool)GetValue(ShowSubWindow1Property); }
            set { SetValue(ShowSubWindow1Property, value); }
        }

        // Using a DependencyProperty as the backing store for ShowSubWindow1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowSubWindow1Property =
            DependencyProperty.Register("ShowSubWindow1", typeof(bool), typeof(MainWindow), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (SubWindow1 != null)
                    {
                        if (SubWindow1.HasShow)
                        {
                            return;
                        }
                    }
                    var mMainWindow = d as MainWindow;
                    SubWindow1 = new SubWindow1();
                    SubWindow1.Owner = Application.Current.MainWindow;
                    SubWindow1.DataContext = mMainWindow.DataContext;
                    SubWindow1.SetBinding(SubWindow1.QuitSubWindow1Property, "QuitSubWindow1");
                    SubWindow1.HasShow = true;
                    SubWindow1.Show();
                })
                
                ));




    }
}
