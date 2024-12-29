using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory 
{ 
    public class InventorySystem : MonoBehaviour
    {
        #region Fields
        //TODO: Refactor: Move this to UICOntroller
        [Header("UI Reffs")]
        [SerializeField] private ItemButton _prefabButton;
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _sellButton;

        [Header("Object Definition")]
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Food[] _foods;
        [SerializeField] private Other[] _others;

        [Header("Item Pool")]
        [SerializeField] private List<Item> _items = new List<Item> ();

        [Header("Item Selected")]
        [SerializeField] private ItemButton _currentItemSelected;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            InitializeItems();
            InitializedUI();

            //TODO: refactor
            _useButton.onClick.AddListener(UseCurrentItem);
            _sellButton.onClick.AddListener(SellCurrentItem);
        }
        #endregion

        #region Private Methods
        //Refactor
        private void UseCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IUsable).Use();

            if (_currentItemSelected.CurrentItem is IConsumible)
                Consume(_currentItemSelected);
        }

        //Refactor
        private void SellCurrentItem()
        {
            (_currentItemSelected.CurrentItem as ISellable).Sell();
                Consume(_currentItemSelected);
        }

        private void Consume(ItemButton currentItemSelected)
        {
            Destroy(_currentItemSelected.gameObject);
            _currentItemSelected = null;

            //Disenable buttons
            _useButton.gameObject.SetActive(false);
            _sellButton.gameObject.SetActive(false);
        }

        private void InitializeItems()
        {
            //Weapons
            for (int i = 0; i < _weapons.Length; i++)
                _items.Add(_weapons[i]);

            //Food
            for (int i = 0; i < _foods.Length; i++)
                _items.Add(_foods[i]);

            //Other
            for (int i = 0; i < _others.Length; i++)
                _items.Add(_others[i]);
        }

        private void InitializedUI()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                ItemButton newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
                newButton.CurrentItem = _items[i];
                newButton.OnClick += () => AddItem(newButton);
            }

            _prefabButton.gameObject.SetActive(false);
        }
        #endregion

        #region Public Methods
        public void AddItem(ItemButton buttonItemToAdd)
        {
           ItemButton newItem = Instantiate(buttonItemToAdd, _inventoryPanel);
            newItem.CurrentItem = buttonItemToAdd.CurrentItem;
            newItem.OnClick += () => SelectItem(newItem);
        }

        public void SelectItem(ItemButton currentItem)
        {
            _currentItemSelected = currentItem;

            //If Sellable
            if (_currentItemSelected.CurrentItem is ISellable)
                _sellButton.gameObject.SetActive(true);
            else
                _sellButton.gameObject.SetActive(false);

            //If Usable
            if (_currentItemSelected.CurrentItem is IUsable)
                _useButton.gameObject.SetActive(true);
            else
                _useButton.gameObject.SetActive(false);

        }
        #endregion
    }
}