using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterWars.Core;

namespace WaterWars.Core
{
    public class SelectableItem : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Call this when object receives ray
        public void onGetRay()
        {
            AppManager.Instance.SelectedItem = this;
        }
    }
}
    

