using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{
    public interface ISellable
    {
        //Public Properties
        public float Price { get; set; }

        //Public Methods
        public float Sell();
    }
}