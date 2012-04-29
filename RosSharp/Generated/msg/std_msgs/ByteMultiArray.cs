//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-04-29T23:10:41+09:00
// </auto-generated>
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RosSharp.Message;
using RosSharp.Service;
namespace RosSharp.std_msgs
{
    public class ByteMultiArray : IMessage
    {
        public ByteMultiArray()
        {
            layout = new MultiArrayLayout();
            data = new List<byte>();
        }
        public ByteMultiArray(BinaryReader br)
        {
            Deserialize(br);
        }
        public MultiArrayLayout layout { get; set; }
        public List<byte> data { get; set; }
        public string MessageType
        {
            get { return "std_msgs/ByteMultiArray"; }
        }
        public string Md5Sum
        {
            get { return "70ea476cbcfd65ac2f68f3cda1e891fe"; }
        }
        public string MessageDefinition
        {
            get { return "MultiArrayLayout layout\nbyte[] data"; }
        }
        public void Serialize(BinaryWriter bw)
        {
            layout.Serialize(bw);
            bw.Write(data.Count); for(int i=0; i<data.Count; i++) { bw.Write(data[i]);}
        }
        public void Deserialize(BinaryReader br)
        {
            layout = new MultiArrayLayout(br);
            data = new List<byte>(br.ReadInt32()); for(int i=0; i<data.Count; i++) { data[i] = br.ReadByte();}
        }
        public int SerializeLength
        {
            get { return layout.SerializeLength + 4 + data.Sum(x => 1); }
        }
        public bool Equals(ByteMultiArray other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.layout.Equals(layout) && other.data.Equals(data);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ByteMultiArray)) return false;
            return Equals((ByteMultiArray)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = (result * 397) ^ layout.GetHashCode();
                result = (result * 397) ^ data.GetHashCode();
                return result;
            }
        }
    }
}
