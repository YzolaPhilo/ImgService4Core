/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;

using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Protocols.Utilities;
using Thrift.Transports;
using Thrift.Transports.Client;
using Thrift.Transports.Server;



public partial class ImgParameter : TBase
{
  private string _materialName;
  private string _floor;
  private string _lotNum;
  private int _sn;
  private int _slice;
  private int _width;
  private int _height;

  public string MaterialName
  {
    get
    {
      return _materialName;
    }
    set
    {
      __isset.materialName = true;
      this._materialName = value;
    }
  }

  public string Floor
  {
    get
    {
      return _floor;
    }
    set
    {
      __isset.floor = true;
      this._floor = value;
    }
  }

  public string LotNum
  {
    get
    {
      return _lotNum;
    }
    set
    {
      __isset.lotNum = true;
      this._lotNum = value;
    }
  }

  public int Sn
  {
    get
    {
      return _sn;
    }
    set
    {
      __isset.sn = true;
      this._sn = value;
    }
  }

  public int Slice
  {
    get
    {
      return _slice;
    }
    set
    {
      __isset.slice = true;
      this._slice = value;
    }
  }

  public int Width
  {
    get
    {
      return _width;
    }
    set
    {
      __isset.width = true;
      this._width = value;
    }
  }

  public int Height
  {
    get
    {
      return _height;
    }
    set
    {
      __isset.height = true;
      this._height = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool materialName;
    public bool floor;
    public bool lotNum;
    public bool sn;
    public bool slice;
    public bool width;
    public bool height;
  }

  public ImgParameter()
  {
  }

  public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      await iprot.ReadStructBeginAsync(cancellationToken);
      while (true)
      {
        field = await iprot.ReadFieldBeginAsync(cancellationToken);
        if (field.Type == TType.Stop)
        {
          break;
        }

        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String)
            {
              MaterialName = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.String)
            {
              Floor = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.String)
            {
              LotNum = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 4:
            if (field.Type == TType.I32)
            {
              Sn = await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 5:
            if (field.Type == TType.I32)
            {
              Slice = await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 6:
            if (field.Type == TType.I32)
            {
              Width = await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 7:
            if (field.Type == TType.I32)
            {
              Height = await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
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
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
  {
    oprot.IncrementRecursionDepth();
    try
    {
      var struc = new TStruct("ImgParameter");
      await oprot.WriteStructBeginAsync(struc, cancellationToken);
      var field = new TField();
      if (MaterialName != null && __isset.materialName)
      {
        field.Name = "materialName";
        field.Type = TType.String;
        field.ID = 1;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteStringAsync(MaterialName, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (Floor != null && __isset.floor)
      {
        field.Name = "floor";
        field.Type = TType.String;
        field.ID = 2;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteStringAsync(Floor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (LotNum != null && __isset.lotNum)
      {
        field.Name = "lotNum";
        field.Type = TType.String;
        field.ID = 3;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteStringAsync(LotNum, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (__isset.sn)
      {
        field.Name = "sn";
        field.Type = TType.I32;
        field.ID = 4;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async(Sn, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (__isset.slice)
      {
        field.Name = "slice";
        field.Type = TType.I32;
        field.ID = 5;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async(Slice, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (__isset.width)
      {
        field.Name = "width";
        field.Type = TType.I32;
        field.ID = 6;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async(Width, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (__isset.height)
      {
        field.Name = "height";
        field.Type = TType.I32;
        field.ID = 7;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async(Height, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      await oprot.WriteFieldStopAsync(cancellationToken);
      await oprot.WriteStructEndAsync(cancellationToken);
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override string ToString()
  {
    var sb = new StringBuilder("ImgParameter(");
    bool __first = true;
    if (MaterialName != null && __isset.materialName)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("MaterialName: ");
      sb.Append(MaterialName);
    }
    if (Floor != null && __isset.floor)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Floor: ");
      sb.Append(Floor);
    }
    if (LotNum != null && __isset.lotNum)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("LotNum: ");
      sb.Append(LotNum);
    }
    if (__isset.sn)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Sn: ");
      sb.Append(Sn);
    }
    if (__isset.slice)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Slice: ");
      sb.Append(Slice);
    }
    if (__isset.width)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Width: ");
      sb.Append(Width);
    }
    if (__isset.height)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Height: ");
      sb.Append(Height);
    }
    sb.Append(")");
    return sb.ToString();
  }
}

