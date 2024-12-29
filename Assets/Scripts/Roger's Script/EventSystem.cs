using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory 
{ 
    public class EventSystem : MonoBehaviour
    {
        //Private Fields
        [SerializeField] private ItemButton _uiButton;
        [SerializeField] private UIController _UiController;

        //Unity Callbacks
        private void Start ()
        {
           
        }
    }
}