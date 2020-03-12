using System.Threading;
using System.Windows;
using Microsoft.Extensions.Logging.Abstractions;
using Thrift.Protocols;
using Thrift.Server;
using Thrift.Transports;
using Thrift.Transports.Server;

namespace ImgService4Server {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        
        public MainWindow() {
            InitializeComponent();
            //直接启动服务程序
            CancellationToken token = new CancellationToken();
            TServerTransport serverTransport = new TServerSocketTransport(31280);

            TBinaryProtocol.Factory _binFactory = new TBinaryProtocol.Factory();
            TBinaryProtocol.Factory _binFactory_output = new TBinaryProtocol.Factory();

            ImgService.AsyncProcessor Processor = new ImgService.AsyncProcessor(new CImgServImpl());

            Thrift.Server.TBaseServer server = new AsyncBaseServer(Processor, serverTransport, _binFactory, _binFactory_output, new NullLoggerFactory());
            server.ServeAsync(token);
        }
    }
}
