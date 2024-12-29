using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inventory 
{
    public class ItemButton : MonoBehaviour
    {
        #region Fields
        private Button _button;
        private Item _currentItem;
        private TextMeshProUGUI _buttonText;
        #endregion

        #region Properties
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
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
            //Delegate example
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }
        #endregion

        #region Events
        public event Action OnClick;
        #endregion
    }

}