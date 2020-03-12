service ImgService {
    InvokeResult ImgStreamTransfer(1:binary imgPtr, 2:ImgParameter param)
}

enum ResponseCode {
  SUCCESS = 0,  
  FAILED = 1,  
}

struct InvokeResult {
    1: required ResponseCode code;
    2: optional string Message;
}

struct ImgParameter {
  1:string materialName
  2:string floor
  3:string lotNum
  4:i32 sn
  5:i32 slice
  6:i32 width
  7:i32 height
}