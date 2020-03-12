using System;
using System.Net;
using System.Threading;
using Thrift;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace ImgService4Client {
    public class CImgService4Client {
        public async System.Threading.Tasks.Task<bool> core4transferAsync(string ipaddress, byte[] imgPtr, string materialName, string floor, string sn, string slice, int width, int height) {
            CancellationToken token = new CancellationToken();
            TClientTransport _transport = new TSocketClientTransport(IPAddress.Parse(ipaddress), 31280);
            TProtocol _protocol = new TBinaryProtocol(_transport);
            ImgService.Client _client = new ImgService.Client(_protocol);

            await _client.OpenTransportAsync(token);
            try {
                ImgParameter _param = new ImgParameter() {
                    MaterialName = materialName,
                    Floor = floor,
                    Sn = sn,
                    Slice = slice,
                    Width = width,
                    Height = height
                };
                _client.ImgStreamTransferAsync(imgPtr, _param, token);
                return true;
            }
            catch (TApplicationException e) {
                return false;
            }
            finally {
                _transport.Close();
            }
        }
    }
}
