using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class DuplicateObject : MonoBehaviour
{
    [SerializeField] private ActiveStateGroup state;
    [SerializeField] private Transform _hand;
    //public GameObject GO;

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
            GameObject newObject = Instantiate(_other.gameObject);
            newObject.transform.position += new Vector3(0.25f, 0, 0);
        }

        // other = _other.gameObject;
        
    }
}

