using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterWars.Core;

namespace WaterWars.UI
{
    public class VehicleControlPanel : MonoBehaviour
    {

        private static VehicleControlPanel _instance;

        public static VehicleControlPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<VehicleControlPanel>();

                return _instance;
            }
        }

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        public void StopVehicle()
        {
            if (AppManager.Instance.SelectedItem != null)
            {
                MovableItem selectedItem = AppManager.Instance.SelectedItem.GetComponent<MovableItem>();

                if (selectedItem != null)
                {
                    selectedItem.Stop();
                }
            }
            
        }
    }
}
