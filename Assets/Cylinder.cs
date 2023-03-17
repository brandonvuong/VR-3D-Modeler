using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public GameObject resizeSphere;
    private BoxCollider parentCollider;

    // Start is called before the first frame update
    void Start()
    {
        parentCollider = transform.parent.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        float newScale_x =  resizeSphere.transform.localPosition.x / 0.35f;    
        float newScale_y =  resizeSphere.transform.localPosition.y / 0.5f / 2;    
        float newScale_z =  resizeSphere.transform.localPosition.z / 0.35f;




        transform.localScale = new Vector3(newScale_x, newScale_y, newScale_z);
        parentCollider.size = new Vector3(newScale_x, newScale_y*2, newScale_z);
    }
}