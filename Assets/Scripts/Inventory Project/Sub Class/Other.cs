using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    [Serializable]
    public class Other : Item, ISellable
    {
        #region Properties
        [field: SerializeField] public float Price { get; set; }
        #endregion

        #region Public Methods
        public float Sell()
        {
            Debug.Log("Has ganado " + Price + "rupias");
            return Price;
        }
        #endregion
    }
}
