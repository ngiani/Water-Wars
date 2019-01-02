using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{

    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject vehicleControlPanel;

        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<UIManager>();

                return _instance;
            }
        }

        // Use this for initialization
        void Start ()
        {
            AppManager.Instance.ItemSelectedEvent += ActivateControlPanel;
	    }

        // Update is called once per frame
        void Update ()
        {
		
	    }


        private void ActivateControlPanel(object sender, ItemSelectedArgs e)
        {
            //Activate vehicle control panel if the object is movable
            if (e.itemObj.GetComponent<MovableItem>() != null)
            {
                vehicleControlPanel.SetActive(true);
            }
            else
            {
                vehicleControlPanel.SetActive(false);
            }
        }

    }
}


