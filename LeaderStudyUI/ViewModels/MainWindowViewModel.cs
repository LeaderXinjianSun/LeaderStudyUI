using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderStudyUI.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        #region 属性绑定
        private string myString;

        public string MyString
        {
            get { return myString; }
            set
            {
                myString = value;
                this.RaisePropertyChanged("MyString");
            }
        }
        private ObservableCollection<string> myStrings;

        public ObservableCollection<string> MyStrings
        {
            get { return myStrings; }
            set
            {
                myStrings = value;
                this.RaisePropertyChanged("MyStrings");
            }
        }
        private bool showSubWindow1;

        public bool ShowSubWindow1
        {
            get { return showSubWindow1; }
            set
            {
                showSubWindow1 = value;
                this.RaisePropertyChanged("ShowSubWindow1");
            }
        }
        private string subWindow1TextBlock;

        public string SubWindow1TextBlock
        {
            get { return subWindow1TextBlock; }
            set
            {
                subWindow1TextBlock = value;
                this.RaisePropertyChanged("SubWindow1TextBlock");
            }
        }
        private bool quitSubWindow1;

        public bool QuitSubWindow1
        {
            get { return quitSubWindow1; }
            set
            {
                quitSubWindow1 = value;
                this.RaisePropertyChanged("QuitSubWindow1");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand<object> MyButtonCommand { get; set; }
        public DelegateCommand AppLoadedCommond { get; set; }
        #endregion

        #region 构造函数
        public MainWindowViewModel()
        {
           
            MyStrings = new ObservableCollection<string>();
            for (int i = 0; i < 7; i++)
            {
                MyStrings.Add(i.ToString());
            }
            this.MyButtonCommand = new DelegateCommand<object>(new Action<object>(MyButtonCommandExecute));
            this.AppLoadedCommond = new DelegateCommand(new Action(AppLoadedCommondExecute));
        }
        #endregion

        #region 方法绑定函数
        private void MyButtonCommandExecute(object p)
        {
            switch (p.ToString())
            {
                case "0":
                    MyString = Guid.NewGuid().ToString();
                    break;
                case "1":
                    for (int i = 0; i < 7; i++)
                    {
                        MyStrings[i] = Guid.NewGuid().ToString();
                    }
                    break;
                case "2":
                    ShowSubWindow1 = !ShowSubWindow1;
                    break;
                case "3":
                    QuitSubWindow1 = !QuitSubWindow1;
                    break;
                default:
                    break;
            }

            //await Task.Run(()=> {
            //    //System.Threading.Thread.Sleep(1000);
            //    MyString = Guid.NewGuid().ToString();
            //});  
        }
        private void AppLoadedCommondExecute()
        {
            MyString = "Hello World123";
            SubWindow1TextBlock = "20200324";
        }
        #endregion

    }
}
