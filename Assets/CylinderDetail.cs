using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CylinderDetail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshPro _r1, _r2, _height;
    private Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _r1.text = tr.localScale.z.ToString("f2");
        _r2.text = tr.localScale.x.ToString("f2");
        _height.text = tr.localScale.y.ToString("f2");
    }
}