using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{
    public interface ISellable
    {
        #region Properties
        public float Price { get; set; }
        #endregion

        #region Public Methods
        public float Sell();
        #endregion
    }
}