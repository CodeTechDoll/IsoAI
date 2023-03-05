using DataTypes;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataFlow
{
    public interface IDataSerializer<T, U> where T : DataObject<U> where U : class
    {
        T Deserialize(string data);
        string Serialize(T obj);
    }
}