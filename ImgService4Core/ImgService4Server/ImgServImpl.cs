using NLog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Thrift;

namespace ImgService4Server {
    public class CImgServImpl : ImgService.IAsync {

        Logger logger = LogManager.GetLogger("*");

        public unsafe Task<InvokeResult> ImgStreamTransferAsync(byte[] imgPtr, ImgParameter param, CancellationToken cancellationToken) {
            return Task.Run(() => {
                InvokeResult result = new InvokeResult() {
                    Code = ResponseCode.FAILED
                };
                try {

                    if (Directory.Exists("D:\\Gerber") == false) {
                        throw new TApplicationException(TApplicationException.ExceptionType.InternalError, $"主目录不存在");
                    }

                    string filename =
                        $"D:\\Gerber\\{param.MaterialName}\\{param.Floor}\\{param.LotNum}\\(ccd)Seq{param.Sn.ToString("D4")}\\";
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

                    Rectangle rect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
                    BitmapData bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bmp.PixelFormat);
                    Marshal.Copy(imgPtr, 0, bmpData.Scan0, param.Width * param.Height);
                    _bmp.UnlockBits(bmpData);
                    _bmp.Save(filename, ImageFormat.Bmp);
                    _bmp.Dispose();
                    Debug.WriteLine(filename + ", " + param.Height * param.Width, "imgs");

                    result.Code = ResponseCode.SUCCESS;
                    return result;
                } catch (TApplicationException e) {
                    logger.Info(e.Message);
                    result.Message = e.Message;
                    return result;
                } catch (Exception ex) {
                    logger.Info(ex.Message);
                    result.Message = ex.Message;
                    return result;
                }
            });
        }
    }
}
