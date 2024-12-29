using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    [Serializable]
    public class Food : Item, IUsable, ISellable, IConsumible
    {
        #region Properties
        [field: SerializeField] public float HealingPoints { get; set; }
        [field: SerializeField] public float Price { get; set; }
        #endregion

        #region Public Methods
        public float Sell()
        {
            Debug.Log("Has ganado " + Price + "rupias");
            return Price;
        }
       
        public void Use() => Debug.Log("Has comido " + Name + "y ganas " + HealingPoints + " de salud.");
        #endregion
    }

}