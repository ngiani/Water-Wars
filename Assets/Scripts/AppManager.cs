using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WaterWars.Core
{

    public class ItemSelectedArgs : EventArgs
    {
        public GameObject itemObj;

        public ItemSelectedArgs(GameObject itemObj)
        {
            this.itemObj = itemObj;
        }
    }

    public class AppManager : MonoBehaviour
    {
        private static AppManager _instance;

        public static AppManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AppManager>();

                return _instance;
            }
        }

        public event EventHandler<ItemSelectedArgs> ItemSelectedEvent;

        [SerializeField]
        private SelectableItem _selectedItem;

        public SelectableItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;

                ItemSelectedEvent.Invoke(this, new ItemSelectedArgs(_selectedItem.transform.GetChild(0).gameObject));
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
    
