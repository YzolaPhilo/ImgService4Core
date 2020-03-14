using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using NLog;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace ImgService4Server {
    public class CImgService {
        private Int32 _port = 9093;
        private TServer _server = null;
        private TServerSocket  _serverSocket = null;
        private Int32 _timeout = 0;
        private ImgService.Processor _processor = null;
        private TProtocolFactory _protocolFactory = null;
        private Logger _logger = LogManager.GetLogger("ImgService");
        public CImgService(Int32 port, Int32 timeout) {
            _port = port;
            _timeout = timeout;
            _serverSocket = new TServerSocket(_port, _timeout, false);
            _processor = new ImgService.Processor(new ImgServiceImpl());
            _server = new TThreadPoolServer(new TSingletonProcessorFactory(_processor), _serverSocket, null, null, _protocolFactory, _protocolFactory, new TThreadPoolServer.Configuration(5, 10), str => { });
        }

        public async Task<bool> StartImgService() {
            return await Task<bool>.Run(() => {
                try {
                    _server.Serve();
                    return false;
                }
                catch (TApplicationException e) {
                    _logger.Error("服务启动失败!", e);
                    return false;
                }
            });
        }
    }
    public class ImgServiceImpl : ImgService.Iface {
        Logger _logger = LogManager.GetLogger("ImgService");
        public InvokeResult ImgStreamTransfer(byte[] imgPtr, ImgParameter param) {
            InvokeResult result = new InvokeResult() {
                Code = ResponseCode.FAILED
            };
            try {
                _logger.Info($"ImgStreamTransfer >>> {param.Width}, {param.Height}, {imgPtr.Length}, {param.Sn}, {param.Slice}, {param.LotNum}, {param.Floor}, {param.MaterialName}");

                if (Directory.Exists("D:\\Gerber") == false) {
                    throw new TApplicationException(TApplicationException.ExceptionType.InternalError, $"主目录不存在");
                }

                string filename =
                    $"D:\\Gerber\\{param.MaterialName}\\{param.Floor}\\{param.LotNum}\\(ccd)Seq{param.Sn.ToString("D4")}\\";
                _logger.Info($"save file path : {filename}");
                DirectoryInfo _di = Directory.CreateDirectory(filename);
                if (_di.Exists == false) {
                    throw new TApplicationException(TApplicationException.ExceptionType.InternalError,
                        $"无法创建目录{filename}");
                }

                if (param.Floor == "TOP") {
                    filename = filename + $"1-{param.Slice}.bmp";
                } else if (param.Floor == "BOT") {
                    filename = filename + $"2-{param.Slice}.bmp";
                } else {
                    throw new TApplicationException(TApplicationException.ExceptionType.InternalError,
                        "，错误的Floor类型");
                }

                Bitmap _bmp = new Bitmap(param.Width, param.Height, PixelFormat.Format8bppIndexed);
                ColorPalette pal = _bmp.Palette;
                for (int i = 0; i <= 255; i++) {
                    pal.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                _bmp.Palette = pal;

                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, _bmp.Width, _bmp.Height);
                BitmapData bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bmp.PixelFormat);
                Marshal.Copy(imgPtr, 0, bmpData.Scan0, param.Width * param.Height);
                _bmp.UnlockBits(bmpData);
                _bmp.Save(filename, ImageFormat.Bmp);
                _bmp.Dispose();

                result.Code = ResponseCode.SUCCESS;
                return result;
            } catch (TApplicationException e) {
                _logger.Error("", e);
                result.Message = e.Message;
                return result;
            } catch (Exception ex) {
                _logger.Error(ex.Message, ex);
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
