using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SphereDetail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshPro _radius;
    private Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _radius.text = tr.localScale.z.ToString("f2");
    }
}