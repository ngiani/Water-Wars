using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterWars.Core;

namespace WaterWars.UI
{
    public class FactoryControlPanel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Build()
        {
            if (AppManager.Instance.SelectedItem != null)
            {
                BuildingItem selectedItem = AppManager.Instance.SelectedItem.GetComponent<BuildingItem>();

                if (selectedItem != null)
                {
                    selectedItem.Build();
                }
            }
        }
    }
}

