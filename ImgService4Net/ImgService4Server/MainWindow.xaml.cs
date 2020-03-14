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
using Thrift.Server;
using Thrift.Transport;

namespace ImgService4Server {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        private CImgService _cImg = new CImgService(31280, 30000);
        public MainWindow() {
            InitializeComponent();
            _cImg.StartImgService();
        }
    }
}
