using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WaterWars.Core
{
    public class PhysicsManager : MonoBehaviour
    {
        [SerializeField] float maxRaycastDistance;

        private static PhysicsManager _instance;


        public static PhysicsManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<PhysicsManager>();

                return _instance;
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

        public void SendRay()
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, maxRaycastDistance))
            {
                hitInfo.transform.gameObject.SendMessage("onGetRay");
            }
        }
    }
}

