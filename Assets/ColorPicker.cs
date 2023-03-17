using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Texture2D _colorPad;
    [SerializeField] private Transform tip;
    private float _tipHeight;
    private Texture2D _texture;
    private RaycastHit _touch;
    private Vector2 _touchPos;
    private Color _colorSelected;
    private int _width, _height;
    private Material _targetMaterial;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _tipHeight = 0.05f;
        _width = _colorPad.width;
        _height = _colorPad.height;
        // Debug.Log("colorpad is x " + _colorPad.width + "y "  + _colorPad.height);
        // _width = 512;

        // Debug.Log("colorpad is x " + _width + "y "  + _height);

    }

    // Update is called once per frame
    void Update()
    {
        // Color pickedColor = _colorPad.GetPixel(50, 50);
        if (Physics.Raycast(tip.position, transform.forward, out _touch, _tipHeight))
        {
            // Debug.Log("hit mesh is " + _touch.collider);

            // Debug.Log("hit mesh is " + _touch.collider);
            
            if (_touch.transform.CompareTag("ColorPad"))
            {
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);
                // Debug.Log("touch pose is x " + _touchPos.x + "y "  + _touchPos.y + "width" + _width);

                var x = (int)(_touchPos.x * _width);
                var y = (int)(_touchPos.y * _height);
                // Debug.Log("x is " +x + "y is " + y);
                
                if (x < 0 || x > _width || y < 0 || y > _height)
                {
                    Debug.Log("outside of color pad");
                }
                _colorSelected = _colorPad.GetPixel(x, y);
                // Debug.Log("color is " + _colorSelected);

                _targetMaterial.color = _colorSelected;
            }
            else
            {
                // Debug.Log("not color pad :" + _touch.collider);
            }
        }
    }

    public void UpdateTargetGameObject(Material material)
    {
        _targetMaterial = material;
    }

}
