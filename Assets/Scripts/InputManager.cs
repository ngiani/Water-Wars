using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WaterWars.Core
{
    [System.Serializable]
    public class KeyboardEvent : UnityEvent<string>
    {

    }

    public class InputManager : MonoBehaviour
    {
        [SerializeField] KeyCode[] supportedKeys;
        [SerializeField] List<KeyboardEvent> keyHoldEvents;
        [SerializeField] List<KeyboardEvent> keyPressedEvents;
        [SerializeField] UnityEvent LeftClick;
        [SerializeField] UnityEvent DoubleLeftClick;
        [SerializeField] UnityEvent RightClick;
        [SerializeField] UnityEvent LeftMouseBtnHold;
        [SerializeField] UnityEvent RightMouseBtnHold;
        [SerializeField] UnityEvent MouseWheelScrollUp;
        [SerializeField] UnityEvent MouseWheelScrollDown;
        [SerializeField] float doubleClickDelta;

        float lastClickTime;

        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<InputManager>();

                return _instance;
            }
        }


        // Use this for initialization
        void Start ()
        {
            DontDestroyOnLoad(this);
            lastClickTime = float.NegativeInfinity;
	    }
	
	    // Update is called once per frame
	    void Update ()
        {
            //Each key should be bound to an event.
            for (int i = 0; i < supportedKeys.Length; i++)
            {
                //if key is being held down for multiple frames, invoke related key hold event if event exists and has a listener 
                if (Input.GetKey(supportedKeys[i]))
                {
                    if (i < keyHoldEvents.Count && keyHoldEvents[i] != null && keyHoldEvents[i].GetPersistentEventCount() > 0)
                    {
                        keyHoldEvents[i].Invoke(supportedKeys[i].ToString());
                        break;
                    }    
                }

                //if key is pressed just in this frame, invoke related key pressed event if event exists and has a listener 
                if (Input.GetKeyDown(supportedKeys[i]))
                {
                    if (i < keyHoldEvents.Count && keyPressedEvents[i] != null && keyPressedEvents[i].GetPersistentEventCount() > 0)
                    {
                        keyPressedEvents[i].Invoke(supportedKeys[i].ToString());
                        break;
                    }
                }
            }

            //Detect mouse button click (single or double), and invoke related event
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastClickTime <= doubleClickDelta)
                {
                    if (DoubleLeftClick != null && DoubleLeftClick.GetPersistentEventCount() > 0)
                        DoubleLeftClick.Invoke();

                }
                   
                else
                {
                    if (LeftClick != null && LeftClick.GetPersistentEventCount() > 0)
                        LeftClick.Invoke();
                }

                lastClickTime = Time.time;
            }

            else if (Input.GetMouseButtonDown(1))
            {
                if (RightClick!=null && RightClick.GetPersistentEventCount() > 0)
                    RightClick.Invoke();
            }

            //Detect mouse button being held down for multiple frames, and invoke related event
            if (Input.GetMouseButton(0))
            {
                if (LeftMouseBtnHold != null && LeftMouseBtnHold.GetPersistentEventCount() > 0)
                    LeftMouseBtnHold.Invoke();
            }

            else if (Input.GetMouseButton(1))
            {
                if (RightMouseBtnHold != null && RightMouseBtnHold.GetPersistentEventCount() > 0)
                    RightMouseBtnHold.Invoke();
            }

            //Detect mouse wheel scroll up or down, and invoke related event
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (MouseWheelScrollUp!=null && MouseWheelScrollUp.GetPersistentEventCount() > 0)
                    MouseWheelScrollUp.Invoke();
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (MouseWheelScrollDown!=null && MouseWheelScrollDown.GetPersistentEventCount() > 0)
                    MouseWheelScrollDown.Invoke();
            }
        }
    }
}

