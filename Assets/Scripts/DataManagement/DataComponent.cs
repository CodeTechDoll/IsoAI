using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataManagement
{
	public abstract class DataComponent : YComponent
	{
        public Dictionary<string, object> data;

        public object GetData(string key)
        {
            if (data.ContainsKey(key))
            {
                return data[key];
            }
            return null;
        }

        public void SetData(string key, object value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
            }
            else
            {
                data.Add(key, value);
            }
        }
    }
}