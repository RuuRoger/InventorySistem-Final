using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inventory 
{
    //Private Fields
    public class ItemButton : MonoBehaviour
    {
        //Private Fields
        private Button _button;
        private Item _currentItem;
        private TextMeshProUGUI _buttonText;

        //Events
        public event Action OnClick;

        //Public Properties
        public Button Button { get; set; }

        public Item CurrentItem 
        {
            get
            { 
                return _currentItem;
            }
            set
            {
                _currentItem = value;
                _buttonText.text = _currentItem.Name;
            }
        }

        //Unity Callbacks
        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
            //Delegate example
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }
    }

}