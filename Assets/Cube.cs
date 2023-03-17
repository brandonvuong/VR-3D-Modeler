using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SceneManagement;
using UnityEngine;

namespace Oculus.Interaction.HandPosing
{


    public class Cube : MonoBehaviour
    {
        public GameObject resizeSphere;
        private Material myMaterial;
        private Transform tr;
        private Color originalColor;
        private BoxCollider parentCollider;

        // Start is called before the first frame update
        void Start()
        {
            originalColor =  GetComponent<Renderer>().material.color;
            myMaterial = GetComponent<Renderer>().material;
            tr = transform;
            parentCollider = transform.parent.GetComponent<BoxCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            // float newPos_x = (resizeSphere.transform.localPosition.x - 0.5f) / 2;
            // float newScale_x =  resizeSphere.transform.localPosition.x + 0.5f;        
            // float newPos_y = (resizeSphere.transform.localPosition.y - 0.5f) / 2;
            // float newScale_y =  resizeSphere.transform.localPosition.y + 0.5f;       
            // float newPos_z = (resizeSphere.transform.localPosition.z - 0.5f) / 2;
            // float newScale_z =  resizeSphere.transform.localPosition.z + 0.5f;
            float newScale_x = resizeSphere.transform.localPosition.x / 0.5f;
            float newScale_y = resizeSphere.transform.localPosition.y / 0.5f;
            float newScale_z = resizeSphere.transform.localPosition.z / 0.5f;


            parentCollider.size = tr.localScale = new Vector3(newScale_x, newScale_y, newScale_z);
/*            parentCollider.size = new Vector3(newScale_x, newScale_y, newScale_z);
*/
        }
        
    }
}