using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject resizeSphere;
    public SphereCollider parentCollider;

    // Start is called before the first frame update
    void Start()
    {
        parentCollider = transform.parent.GetComponent<SphereCollider>();
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
        // float newScale_x =  resizeSphere.transform.localPosition.x / 0.5f;    
        // float newScale_y =  resizeSphere.transform.localPosition.y / 0.5f;    
        float newScale =  resizeSphere.transform.localPosition.z / 0.5f;  
     
        
        
        
        transform.localScale = new Vector3(newScale, newScale, newScale);
        resizeSphere.transform.localPosition = new Vector3(0, 0, resizeSphere.transform.localPosition.z);
        parentCollider.radius = newScale/2;
        // transform.localPosition = new Vector3(newPos_x, newPos_y, newPos_z);
    }
}
