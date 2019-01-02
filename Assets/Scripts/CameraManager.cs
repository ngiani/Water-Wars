using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{ 
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Camera myCamera;
        [SerializeField] float moveSpeed;
        [SerializeField] float zoomSpeed;
        [SerializeField] float zoomRotationSpeed;
        [SerializeField] float rotationSpeed;
        [SerializeField] Vector3 originalEulerRotation;

        Vector3 currenEulerRotation;
        Vector3 rotationPivot;
        Transform originalCameraParent;

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

        private bool _canMoveToTarget;

        public bool CanMoveToTarget
        {
            get { return _canMoveToTarget; }
            set { _canMoveToTarget = value; }
        }

        // Use this for initialization
        void Start ()
        {
            AppManager.Instance.ItemSelectedEvent += ItemSelectedHandler;
            currenEulerRotation = originalEulerRotation;
            originalCameraParent = transform.parent;
            DOTween.Init();
        }

        private void ItemSelectedHandler(object sender, ItemSelectedArgs e)
        {
            HandleSelectObj(e.itemObj);
        }

        // Update is called once per frame
        void Update ()
        {

	    }

        public void MoveForward()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }

        public void MoveBackward()
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }

        public void MoveLeft()
        {
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }

        public void ZoomIn()
        {
            if (currenEulerRotation.x >= 0)
            {

                myCamera.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime, Space.Self);
                currenEulerRotation -= Vector3.right * zoomRotationSpeed * Time.deltaTime;
                myCamera.transform.localEulerAngles = currenEulerRotation;
            }

        }

        public void ZoomOut()
        {
            if (currenEulerRotation.x <= 90)
            {
                myCamera.transform.Translate(-Vector3.forward * zoomSpeed * Time.deltaTime, Space.Self);
                currenEulerRotation += Vector3.right * zoomRotationSpeed * Time.deltaTime;
                myCamera.transform.localEulerAngles = currenEulerRotation;
            }
        }

        public void SetRotationPivot()
        {
            rotationPivot = Input.mousePosition;
        }

        public void Rotate()
        {
            if (Input.mousePosition.x > rotationPivot.x)
                transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime, Space.Self);

            else if (Input.mousePosition.x < rotationPivot.x)
                transform.Rotate(new Vector3(0, 1, 0), -rotationSpeed * Time.deltaTime, Space.Self);
        }


        void MoveTo(GameObject target)
        {
            if (_canMoveToTarget)
            {
                 //Smoothly move to target and align to its rotation 
                transform.DOMove(target.transform.position, 3.0f);
                transform.DORotate(new Vector3(0, target.transform.eulerAngles.y, 0), 3.0f);
                myCamera.transform.DOLocalMove(new Vector3(0, 0, 0), 3.0f);
                myCamera.transform.DOLocalRotate(target.transform.localRotation.eulerAngles, 3.0f);

                DOTween.PlayAll();

                currenEulerRotation = originalEulerRotation;

                _canMoveToTarget = false;
            }
        }

        void HandleSelectObj(GameObject obj)
        {
            if (obj.GetComponent<SelectableItem>())
            {
                transform.parent = originalCameraParent;

                MoveTo(obj.transform.GetChild(0).gameObject);
            }


        }
    }
}
