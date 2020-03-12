using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace ImgService4Server {
    public class CImgServImpl : ImgService.IAsync {

        Logger logger = LogManager.GetLogger("*");

        public Task<InvokeResult> ImgStreamTransferAsync(byte[] imgPtr, ImgParameter param, CancellationToken cancellationToken) {
            return Task.Run(() => {
                InvokeResult result = new InvokeResult();
                logger.Info(imgPtr.Length + ", " + param.Width * param.Height);
                return result;
            });
        }
    }
}
