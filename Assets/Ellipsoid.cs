using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipsoid : MonoBehaviour
{
    public GameObject resizeSphere;
    public BoxCollider parentCollider;
    // Start is called before the first frame update
    void Start()
    {
        parentCollider = transform.parent.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float newScale_x =  resizeSphere.transform.localPosition.x / 0.28f;    
        float newScale_y =  resizeSphere.transform.localPosition.y / 0.28f;    
        float newScale_z =  resizeSphere.transform.localPosition.z / 0.28f;    
     
        
        
        
        transform.localScale = new Vector3(newScale_x, newScale_y, newScale_z);
        parentCollider.size = transform.localScale = new Vector3(newScale_x, newScale_y, newScale_z);

    }
}
