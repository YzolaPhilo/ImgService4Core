using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace ImgService4Server {
    public class CImgServImpl : ImgService.IAsync {

        Logger logger = LogManager.GetLogger("*");
        public Task<InvokeResult> ImgStreamTransferAsync(byte[] imgPtr, string jsonParam, CancellationToken cancellationToken = default) {
            return Task.Run(() => {
                InvokeResult result = new InvokeResult();
                logger.Info(imgPtr.Length + ", " + jsonParam);
                return result;
            });
        }
    }
}
