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
        [SerializeField] UnityEvent onLeftClick;
        [SerializeField] UnityEvent onRightClick;
        [SerializeField] UnityEvent onMouseWheelScrollUp;
        [SerializeField] UnityEvent onMouseWheelScrollDown;

        // Use this for initialization
        void Start ()
        {
            DontDestroyOnLoad(this);
	    }
	
	    // Update is called once per frame
	    void Update ()
        {
            //Each key should be bound to an event.
            for (int i = 0; i < supportedKeys.Length; i++)
            {
                //if key is held down, invoke a key hold event if event exists and has a listener 
                if (Input.GetKey(supportedKeys[i]))
                {
                    if (i < keyHoldEvents.Count && keyHoldEvents[i] != null)
                    {
                        Debug.Log("Key hold: " + supportedKeys[i]);
                        keyHoldEvents[i].Invoke(supportedKeys[i].ToString());
                        break;
                    }    
                }

                //if key is pressed just in this frame, invoke a key pressed event if event exists and has a listener . Don't call again until is released
                if (Input.GetKeyDown(supportedKeys[i]))
                {
                    if (i < keyHoldEvents.Count && keyPressedEvents[i] != null)
                    {
                        Debug.Log("Key pressed: " + supportedKeys[i]);
                        keyPressedEvents[i].Invoke(supportedKeys[i].ToString());
                        break;
                    }
                }
            }

            //Detect mouse button click, and invoke related event
            if (Input.GetMouseButtonDown(0))
            {
                if (onLeftClick!=null)
                    onLeftClick.Invoke();

                Debug.Log("Left click");
            }

            else if (Input.GetMouseButtonDown(1))
            {
                if (onRightClick!=null)
                    onRightClick.Invoke();

                Debug.Log("Right click");
            }

            //Detect mouse wheel scroll up or down, and invoke related event
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (onMouseWheelScrollUp!=null)
                    onMouseWheelScrollUp.Invoke();

                Debug.Log("Mouse wheel up");
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (onMouseWheelScrollDown!=null)
                    onMouseWheelScrollDown.Invoke();

                Debug.Log("Mouse wheel down");
            }
        }
    }
}

