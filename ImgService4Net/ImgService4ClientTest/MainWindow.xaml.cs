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
using ImgService4Client;

namespace ImgService4ClientTest {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            byte[] imgPtrs = new byte[8192 * 10000];
            for (int i = 0; i < 8192 * 10000; i++) {
                imgPtrs[i] = (byte)(i * 255);
            }

            Task[] a = new Task[4];
            for (int i = 0; i < 4; i++) {
                a[i] = new Task(
                    x => {
                        CImgService4Client.net4transferAsync("172.16.90.1", imgPtrs, "Test", "TOP", "1", 1, (int)x, 8192,
                            10000);
                    }, i);
                a[i].Start();
            }

            Task.WaitAll(a.ToArray());

        }
    }
}
