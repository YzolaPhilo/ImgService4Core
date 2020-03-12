/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;
using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Protocols.Utilities;
using Thrift.Transports;


public partial class ImgService {
    public interface IAsync {
        Task<InvokeResult> ImgStreamTransferAsync(byte[] imgPtr, string jsonParam, CancellationToken cancellationToken = default(CancellationToken));

    }


    public class Client : TBaseClient, IDisposable, IAsync {
        public Client(TProtocol protocol) : this(protocol, protocol) {
        }

        public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol) {
        }
        public async Task<InvokeResult> ImgStreamTransferAsync(byte[] imgPtr, string jsonParam, CancellationToken cancellationToken = default(CancellationToken)) {
            await OutputProtocol.WriteMessageBeginAsync(new TMessage("ImgStreamTransfer", TMessageType.Call, SeqId), cancellationToken);

            var args = new ImgStreamTransferArgs();
            args.ImgPtr = imgPtr;
            args.JsonParam = jsonParam;

            await args.WriteAsync(OutputProtocol, cancellationToken);
            await OutputProtocol.WriteMessageEndAsync(cancellationToken);
            await OutputProtocol.Transport.FlushAsync(cancellationToken);

            var msg = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
            if (msg.Type == TMessageType.Exception) {
                var x = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
                await InputProtocol.ReadMessageEndAsync(cancellationToken);
                throw x;
            }

            var result = new ImgStreamTransferResult();
            await result.ReadAsync(InputProtocol, cancellationToken);
            await InputProtocol.ReadMessageEndAsync(cancellationToken);
            if (result.__isset.success) {
                return result.Success;
            }
            throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "ImgStreamTransfer failed: unknown result");
        }

    }

    public class AsyncProcessor : ITAsyncProcessor {
        private IAsync _iAsync;

        public AsyncProcessor(IAsync iAsync) {
            if (iAsync == null) throw new ArgumentNullException(nameof(iAsync));

            _iAsync = iAsync;
            processMap_["ImgStreamTransfer"] = ImgStreamTransfer_ProcessAsync;
        }

        protected delegate Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken);
        protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

        public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot) {
            return await ProcessAsync(iprot, oprot, CancellationToken.None);
        }

        public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken) {
            try {
                var msg = await iprot.ReadMessageBeginAsync(cancellationToken);

                ProcessFunction fn;
                processMap_.TryGetValue(msg.Name, out fn);

                if (fn == null) {
                    await TProtocolUtil.SkipAsync(iprot, TType.Struct, cancellationToken);
                    await iprot.ReadMessageEndAsync(cancellationToken);
                    var x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                    await oprot.WriteMessageBeginAsync(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID), cancellationToken);
                    await x.WriteAsync(oprot, cancellationToken);
                    await oprot.WriteMessageEndAsync(cancellationToken);
                    await oprot.Transport.FlushAsync(cancellationToken);
                    return true;
                }

                await fn(msg.SeqID, iprot, oprot, cancellationToken);

            } catch (IOException) {
                return false;
            }

            return true;
        }

        public async Task ImgStreamTransfer_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken) {
            var args = new ImgStreamTransferArgs();
            await args.ReadAsync(iprot, cancellationToken);
            await iprot.ReadMessageEndAsync(cancellationToken);
            var result = new ImgStreamTransferResult();
            try {
                result.Success = await _iAsync.ImgStreamTransferAsync(args.ImgPtr, args.JsonParam, cancellationToken);
                await oprot.WriteMessageBeginAsync(new TMessage("ImgStreamTransfer", TMessageType.Reply, seqid), cancellationToken);
                await result.WriteAsync(oprot, cancellationToken);
            } catch (TTransportException) {
                throw;
            } catch (Exception ex) {
                Console.Error.WriteLine("Error occurred in processor:");
                Console.Error.WriteLine(ex.ToString());
                var x = new TApplicationException(TApplicationException.ExceptionType.InternalError, " Internal error.");
                await oprot.WriteMessageBeginAsync(new TMessage("ImgStreamTransfer", TMessageType.Exception, seqid), cancellationToken);
                await x.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteMessageEndAsync(cancellationToken);
            await oprot.Transport.FlushAsync(cancellationToken);
        }

    }


    public partial class ImgStreamTransferArgs : TBase {
        private byte[] _imgPtr;
        private string _jsonParam;

        public byte[] ImgPtr {
            get {
                return _imgPtr;
            }
            set {
                __isset.imgPtr = true;
                this._imgPtr = value;
            }
        }

        public string JsonParam {
            get {
                return _jsonParam;
            }
            set {
                __isset.jsonParam = true;
                this._jsonParam = value;
            }
        }


        public Isset __isset;
        public struct Isset {
            public bool imgPtr;
            public bool jsonParam;
        }

        public ImgStreamTransferArgs() {
        }

        public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken) {
            iprot.IncrementRecursionDepth();
            try {
                TField field;
                await iprot.ReadStructBeginAsync(cancellationToken);
                while (true) {
                    field = await iprot.ReadFieldBeginAsync(cancellationToken);
                    if (field.Type == TType.Stop) {
                        break;
                    }

                    switch (field.ID) {
                        case 1:
                            if (field.Type == TType.String) {
                                ImgPtr = await iprot.ReadBinaryAsync(cancellationToken);
                            } else {
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.String) {
                                JsonParam = await iprot.ReadStringAsync(cancellationToken);
                            } else {
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            }
                            break;
                        default:
                            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            break;
                    }

                    await iprot.ReadFieldEndAsync(cancellationToken);
                }

                await iprot.ReadStructEndAsync(cancellationToken);
            } finally {
                iprot.DecrementRecursionDepth();
            }
        }

        public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken) {
            oprot.IncrementRecursionDepth();
            try {
                var struc = new TStruct("ImgStreamTransfer_args");
                await oprot.WriteStructBeginAsync(struc, cancellationToken);
                var field = new TField();
                if (ImgPtr != null && __isset.imgPtr) {
                    field.Name = "imgPtr";
                    field.Type = TType.String;
                    field.ID = 1;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    await oprot.WriteBinaryAsync(ImgPtr, cancellationToken);
                    await oprot.WriteFieldEndAsync(cancellationToken);
                }
                if (JsonParam != null && __isset.jsonParam) {
                    field.Name = "jsonParam";
                    field.Type = TType.String;
                    field.ID = 2;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    await oprot.WriteStringAsync(JsonParam, cancellationToken);
                    await oprot.WriteFieldEndAsync(cancellationToken);
                }
                await oprot.WriteFieldStopAsync(cancellationToken);
                await oprot.WriteStructEndAsync(cancellationToken);
            } finally {
                oprot.DecrementRecursionDepth();
            }
        }

        public override bool Equals(object that) {
            var other = that as ImgStreamTransferArgs;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return ((__isset.imgPtr == other.__isset.imgPtr) && ((!__isset.imgPtr) || (TCollections.Equals(ImgPtr, other.ImgPtr))))
              && ((__isset.jsonParam == other.__isset.jsonParam) && ((!__isset.jsonParam) || (System.Object.Equals(JsonParam, other.JsonParam))));
        }

        public override int GetHashCode() {
            int hashcode = 157;
            unchecked {
                if (__isset.imgPtr)
                    hashcode = (hashcode * 397) + ImgPtr.GetHashCode();
                if (__isset.jsonParam)
                    hashcode = (hashcode * 397) + JsonParam.GetHashCode();
            }
            return hashcode;
        }

        public override string ToString() {
            var sb = new StringBuilder("ImgStreamTransfer_args(");
            bool __first = true;
            if (ImgPtr != null && __isset.imgPtr) {
                if (!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("ImgPtr: ");
                sb.Append(ImgPtr);
            }
            if (JsonParam != null && __isset.jsonParam) {
                if (!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("JsonParam: ");
                sb.Append(JsonParam);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }


    public partial class ImgStreamTransferResult : TBase {
        private InvokeResult _success;

        public InvokeResult Success {
            get {
                return _success;
            }
            set {
                __isset.success = true;
                this._success = value;
            }
        }


        public Isset __isset;
        public struct Isset {
            public bool success;
        }

        public ImgStreamTransferResult() {
        }

        public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken) {
            iprot.IncrementRecursionDepth();
            try {
                TField field;
                await iprot.ReadStructBeginAsync(cancellationToken);
                while (true) {
                    field = await iprot.ReadFieldBeginAsync(cancellationToken);
                    if (field.Type == TType.Stop) {
                        break;
                    }

                    switch (field.ID) {
                        case 0:
                            if (field.Type == TType.Struct) {
                                Success = new InvokeResult();
                                await Success.ReadAsync(iprot, cancellationToken);
                            } else {
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            }
                            break;
                        default:
                            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            break;
                    }

                    await iprot.ReadFieldEndAsync(cancellationToken);
                }

                await iprot.ReadStructEndAsync(cancellationToken);
            } finally {
                iprot.DecrementRecursionDepth();
            }
        }

        public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken) {
            oprot.IncrementRecursionDepth();
            try {
                var struc = new TStruct("ImgStreamTransfer_result");
                await oprot.WriteStructBeginAsync(struc, cancellationToken);
                var field = new TField();

                if (this.__isset.success) {
                    if (Success != null) {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        await oprot.WriteFieldBeginAsync(field, cancellationToken);
                        await Success.WriteAsync(oprot, cancellationToken);
                        await oprot.WriteFieldEndAsync(cancellationToken);
                    }
                }
                await oprot.WriteFieldStopAsync(cancellationToken);
                await oprot.WriteStructEndAsync(cancellationToken);
            } finally {
                oprot.DecrementRecursionDepth();
            }
        }

        public override bool Equals(object that) {
            var other = that as ImgStreamTransferResult;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return ((__isset.success == other.__isset.success) && ((!__isset.success) || (System.Object.Equals(Success, other.Success))));
        }

        public override int GetHashCode() {
            int hashcode = 157;
            unchecked {
                if (__isset.success)
                    hashcode = (hashcode * 397) + Success.GetHashCode();
            }
            return hashcode;
        }

        public override string ToString() {
            var sb = new StringBuilder("ImgStreamTransfer_result(");
            bool __first = true;
            if (Success != null && __isset.success) {
                if (!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("Success: ");
                sb.Append(Success);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

}
