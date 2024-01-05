using System.Runtime.Serialization;
using UnityEngine;

public class QuaternionSerialization : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var qu = (Quaternion)obj;
        info.AddValue("x", qu.x);
        info.AddValue("y", qu.y);
        info.AddValue("z", qu.z);
        info.AddValue("w", qu.w);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
        ISurrogateSelector selector)
    {
        var qu = (Quaternion)obj;
        qu.x = (float)info.GetValue("x", typeof(float));
        qu.y = (float)info.GetValue("y", typeof(float));
        qu.z = (float)info.GetValue("z", typeof(float));
        qu.w = (float)info.GetValue("w", typeof(float));
        obj = qu;
        return obj;
    }
}