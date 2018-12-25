using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{ 
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Camera camera;
        [SerializeField] float moveSpeed;
        [SerializeField] float zoomSpeed;
        [SerializeField] float zoomRotationSpeed;
        [SerializeField] float rotationSpeed;
        [SerializeField] Vector3 currentRotation;
        Vector3 rotationPivot;


        private static CameraManager _instance;

        public static CameraManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CameraManager>();

                return _instance;
            }
        }

        // Use this for initialization
        void Start ()
        {

	    }
	
	    // Update is called once per frame
	    void Update ()
        {
		
        

	    }

        public void MoveForward()
        {
            transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime), Space.Self);
        }

        public void MoveBackward()
        {
            transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime), Space.Self);
        }

        public void MoveRight()
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0), Space.Self);
        }

        public void MoveLeft()
        {
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0), Space.Self);
        }

        public void ZoomIn()
        {
            if (currentRotation.x >= 0)
            {

                camera.transform.Translate(new Vector3(0, 0, zoomSpeed * Time.deltaTime), Space.Self);
                currentRotation -= new Vector3(1, 0, 0) * zoomRotationSpeed * Time.deltaTime;
                camera.transform.localEulerAngles = currentRotation;

            }

        }

        public void ZoomOut()
        {
            if (currentRotation.x <= 90)
            {
                camera.transform.Translate(new Vector3(0, 0, -zoomSpeed * Time.deltaTime), Space.Self);
                currentRotation += new Vector3(1, 0, 0) * zoomRotationSpeed * Time.deltaTime;
                camera.transform.localEulerAngles = currentRotation;
            }
        }

        public void SetRotationPivot()
        {
            rotationPivot = Input.mousePosition;
        }

        public void Rotate()
        {
            if (Input.mousePosition.x > rotationPivot.x)
                transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

            else if (Input.mousePosition.x < rotationPivot.x)
                transform.Rotate(new Vector3(0, 1, 0), -rotationSpeed * Time.deltaTime);
        }
    }
}
