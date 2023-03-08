using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public abstract class GameEvent<T>
    {
        public T Data { get; private set; }

        public GameEvent(T data)
        {
            Data = data;
        }
    }

}