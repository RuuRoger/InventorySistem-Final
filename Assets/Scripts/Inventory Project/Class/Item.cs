using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    [Serializable]
    public class Item
    {
        #region Properties
        [field: SerializeField] public string Name { get; set; }
        #endregion
    }
}