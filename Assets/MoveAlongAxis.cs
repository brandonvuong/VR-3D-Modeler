using System;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.Networking;
using Oculus.Interaction.Grab;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.Input;


namespace Oculus.Interaction.HandPosing
{
    public class MoveAlongAxis : MonoBehaviour
    {
        [SerializeField] private ActiveStateGroup state;
        [SerializeField] private Transform _leftHandTransform;
        private Transform _rightHandTransform;
        [SerializeField] private HandGrabInteractor rightHandGrab;
        [SerializeField] private GameObject rightHand;
        public GameObject GO;
        private bool isGrabbed;
        private bool wasGrabbed;
        private GameObject targetGameObject;

        private float x_pos, y_pos, z_pos;



        // Start is called before the first frame update


        void Start()
        {
            wasGrabbed = isGrabbed = false;

        }

        // Update is called once per frame
        void Update()
        {
            
            transform.position = rightHand.transform.position;
            isGrabbed = (InteractorState.Select == rightHandGrab.State);
            /*Debug.Log("is grabbed" + rightHandGrab.State);*/
            wasGrabbed = isGrabbed;
            if (targetGameObject != null && !wasGrabbed && isGrabbed)
            {
                x_pos = targetGameObject.transform.position.x;
                y_pos = targetGameObject.transform.position.y;
                z_pos = targetGameObject.transform.position.z;
                //GO.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            }
            else if(targetGameObject != null)
            {
                targetGameObject.transform.position = new Vector3(x_pos, targetGameObject.transform.position.y, z_pos);
            }


            if (state.Active == true)
            {
                // GO.transform.position = new Vector3(GO.transform.position.x + 1, 0, 0);
                GO.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            }
            else
            {
                // GO.transform.position = new Vector3(GO.transform.position.x + 1, 5, 0);
                GO.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            }




        }

        private void OnTriggerEnter(Collider _other)
        {
            if (state.Active && _other.CompareTag("Shape"))
            {
                targetGameObject = _other.gameObject;
                /*x_pos = _other.gameObject.transform.position.x;
                y_pos = _other.gameObject.transform.position.y;
                z_pos = _other.gameObject.transform.position.z;
                Debug.Log("enter: x: " + x_pos + " y:"+ y_pos + "z : " + z_pos);*/

            }
        }

        private void OnTriggerExit(Collider other)
        {
            targetGameObject = null;
        }
        /*        private void  OnTriggerStay(Collider _other)
                {
                    if (state.Active && _other.CompareTag("Shape"))
                    {
                        Debug.Log("collide with" + _other.gameObject);
                        Debug.Log("stay: x: " + x_pos + " y:" + y_pos + "z : " + z_pos);

                        _other.gameObject.transform.position = new Vector3(x_pos, _other.gameObject.transform.position.y, z_pos);
                    }

                    // other = _other.gameObject;

                }*/
    }

}