service ImgService {
    InvokeResult ImgStreamTransfer(1:binary imgPtr, 2:string jsonParam)
}

enum ResponseCode {
  SUCCESS = 0,  
  FAILED = 1,  
}

struct InvokeResult {
    1: required ResponseCode code;
    2: optional string Message;
}