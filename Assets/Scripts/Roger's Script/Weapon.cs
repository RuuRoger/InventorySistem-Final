using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    [Serializable]
    public class Weapon : Item, IUsable
    {
        //Public Properties
        [field: SerializeField] public float Damage { get; set; }

        //Public Methods
        public void Attack() => Debug.Log("�Ataque!");

        public void Use() => Attack();
    }
}