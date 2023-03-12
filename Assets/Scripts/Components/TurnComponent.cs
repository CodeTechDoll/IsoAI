using Assets.Scripts.DataTypes.Properties;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class TurnComponent : YComponent
    {
        public Property<int> Turns { get; set; }
        public Property<bool> IsActive { get; set; }
        public Property<bool> HasTakenTurn { get; set; }
        private void Awake()
        {
            Turns = new Property<int>(0);
            IsActive = new Property<bool>(false);
            HasTakenTurn = new Property<bool>(false);
        }

        public void StartTurn()
        {
            IsActive = true;
            HasTakenTurn = true;
            // Update UI, show it's this entity's turn
        }

        public void EndTurn()
        {
            IsActive = false;
            HasTakenTurn = true;
            Turns++;
            // Update UI, show turn has ended
        }

        public void ResetTurn()
        {
            HasTakenTurn = false;
        }
    }
}