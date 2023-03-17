using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDetail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _hand;
    [SerializeField] private GameObject _colorPad;
    [SerializeField] private GameObject _colorPicker;
    

    // Start is called before the first frame update
    
    
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _hand.position;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Shape"))
        {
            GameObject detail = _other.gameObject.transform.Find("ResizeSphere").gameObject;
            detail.SetActive(true); //set detail (resize sphere and dimensions) active
            Material targetMaterial = _other.gameObject.transform.Find("Shape").gameObject.GetComponent<Renderer>().material;
            _colorPad.SetActive(true);
            _colorPicker.GetComponent<ColorPicker>().UpdateTargetGameObject(targetMaterial); //update target go to change color
            Debug.Log("active");
        }

    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Shape"))
        {
            GameObject detail = _other.gameObject.transform.Find("ResizeSphere").gameObject;
            detail.SetActive(false);
            _colorPad.SetActive(false);
            Debug.Log("not active");
        }
    }
}