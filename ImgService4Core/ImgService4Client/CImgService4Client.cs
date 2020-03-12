using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Thrift;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace ImgService4Client {
    public static class CImgService4Client {
        public static async System.Threading.Tasks.Task<bool> core4transferAsync(string ipaddress, byte[] imgPtr, string materialName, string floor, string lotNum, Int32 sn, Int32 slice, Int32 width, Int32 height) {
            CancellationToken token = new CancellationToken();
            TClientTransport _transport = new TSocketClientTransport(IPAddress.Parse(ipaddress), 31280);
            TProtocol _protocol = new TBinaryProtocol(_transport);
            ImgService.Client _client = new ImgService.Client(_protocol);

            await _client.OpenTransportAsync(token);
            try {
                ImgParameter _param = new ImgParameter() {
                    MaterialName = materialName,
                    Floor = floor,
                    LotNum = lotNum,
                    Sn = sn,
                    Slice = slice,
                    Width = width,
                    Height = height
                };
                ResponseCode code = _client.ImgStreamTransferAsync(imgPtr, _param, token).Result.Code;
                return code == ResponseCode.SUCCESS;
            }
            catch (TApplicationException e) {
                Debug.WriteLine(e.Message);
                return false;
            }
            finally {
                _transport.Close();
            }
        }
    }
}
