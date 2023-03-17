using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeDetail : MonoBehaviour
{
    [SerializeField] private TextMeshPro _width, _length, _height;
    private Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _width.text = tr.localScale.z.ToString("f2");
        _length.text = tr.localScale.x.ToString("f2");
        _height.text = tr.localScale.y.ToString("f2");
    }
}
