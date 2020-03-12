using ImgService4Client;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ImgService4ClientTests {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        
        
        private void SendImg_OnClick(object sender, RoutedEventArgs e) {
            byte[] test = new Byte[8192 * 14000];
            string ip = ipaddr.Text;
            Task a = new Task(() => {
                CImgService4Client.core4transferAsync(ip, test, "Test", "BOT", "TST", 1, 1, 8192, 14000);
            });

            Task b = new Task(() => {
                CImgService4Client.core4transferAsync(ip, test, "Test", "TOP", "TST", 1, 2, 8192, 14000);
            });
            a.Start();
            b.Start();

            a.Wait();
            b.Wait();
        }

        private void MSendImg_OnClick(object sender, RoutedEventArgs e) {
            byte[] test = new Byte[8192 * 14000];
            for (int i = 0; i < 8192 * 14000; i++) {
                test[i] = (byte)(i % 255);
            }
            string ip = ipaddr.Text;
            MessageBox.Show("初始化完毕 ！");
            Task[] _tmp = new Task[4];
            int index = 1;
            while (true) {
                for (int i = 0; i < 4; i++) {
                    _tmp[i] = new Task(x => {
                        CImgService4Client.core4transferAsync(ip, test, "Test", "TOP", "TST", index, (int)x, 8192, 14000);
                    }, i+1);
                    _tmp[i].Start();
                }

                Task.WaitAll(_tmp);
                if (index++ > 5) {
                    break;
                }
            }
        }
    }
}
