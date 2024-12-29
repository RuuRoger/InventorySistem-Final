using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    public interface IConsumable { }

    [Serializable]
    public class Food : Item, IUsable, ISellable, IConsumable
    {
        //Public Properties
        [field: SerializeField] public float HealingPoints { get; set; }
        [field: SerializeField] public float Price { get; set; }

        //Public Methods
        public float Sell()
        {
            Debug.Log("Has ganado " + Price + "rupias");
            return Price;
        }

        public void Use() => Debug.Log("Has comido " + Name + "y ganas " + HealingPoints + " de salud.");
    }

}