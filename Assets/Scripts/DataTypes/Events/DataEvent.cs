using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.DataTypes.Events
{
    [System.Serializable]
    public class DataEvent<T> : UnityEvent<T> { }
}