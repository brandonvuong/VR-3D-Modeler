using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] private ActiveStateGroup state;
    [SerializeField] private Transform _hand;
    [SerializeField] private GameObject colorPad;
    // public GameObject other;

    // Start is called before the first frame update
    
    
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _hand.position;
/*        if (state.Active == true)
        {
            // GO.transform.position = new Vector3(GO.transform.position.x + 1, 0, 0);
            GO.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
            // GO.transform.position = new Vector3(GO.transform.position.x + 1, 5, 0);
            GO.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }*/
        
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (state.Active && _other.CompareTag("Shape"))
        {
            
            //Debug.Log(_other.tag);
            Destroy(_other.gameObject);
            colorPad.SetActive(false);
        }

            // other = _other.gameObject;
        
    }
}
