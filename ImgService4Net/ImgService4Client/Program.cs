using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace ImgService4Client {
    public static class CImgService4Client {
        private static Logger _logger = LogManager.GetLogger("ImgService4Client");
        public static bool net4transferAsync(string ipaddress, byte[] imgPtr, string materialName, string floor, string lotNum, Int32 sn, Int32 slice, Int32 width, Int32 height) {
            try {
                _logger.Info($"client接受到任务，开始准备! {ipaddress}, {imgPtr.Length}, {materialName}, {floor}, {lotNum}, {sn}, {slice}, {width}, {height}");

                TTransport transport = new TSocket(ipaddress, 31280, 10000);
                TProtocol protocol = new TCompactProtocol(transport);
                ImgService.Client client = new ImgService.Client(protocol);

                transport.Open();
                Debug.WriteLine("Server 端口已经打开!", "Aoi");
                ImgParameter _param = new ImgParameter() {
                    MaterialName = materialName,
                    Floor = floor,
                    LotNum = lotNum,
                    Sn = sn,
                    Slice = slice+1,
                    Width = width,
                    Height = height
                };
                ResponseCode code = client.ImgStreamTransfer(imgPtr, _param).Code;
                transport.Close();
                _logger.Info($"客户端通信结束! code result: {code}" );
                return code == ResponseCode.SUCCESS;
            }
            catch (TApplicationException e) {
                Debug.WriteLine(e.Message, "Aoi");
                return false;
            }
            catch (Exception e) {
                Debug.WriteLine("", "Aoi");
                return false;
            }
            
        }
    }
}
