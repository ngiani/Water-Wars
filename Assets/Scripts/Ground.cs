using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    public class Ground : MonoBehaviour {

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        //Call this when object receives ray
        public void onGetRay(RaycastHit hitInfo)
        {
            if (AppManager.Instance.SelectedItem != null)
            {
                MovableItem movableItem = AppManager.Instance.SelectedItem.GetComponent<MovableItem>();

                if (movableItem != null)
                {
                    movableItem.MoveTo(hitInfo.point);
                }
            }
        }
    }
}
