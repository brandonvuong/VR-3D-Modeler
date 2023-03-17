using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.Grab;
using Oculus.Interaction.HandPosing;
using OculusSampleFramework;
using UnityEngine;
using InteractableState = OculusSampleFramework.InteractableState;

namespace Oculus.Interaction
{
    public class grabColor : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField, Interface(typeof(IInteractableView))]
        private MonoBehaviour _interactableView;
        [SerializeField] private Renderer _renderer;
        private IInteractableView InteractableView;
        private Material _material;
        private Color originalColor;

        void Start()
        {
            originalColor = _material.color;
            _material = _renderer.material;
        }

        // Update is called once per frame
        void Update()
        {
            //changing color
            if (InteractableView.State == InteractableState.Select)
                _material.color = new Color(0, 255, 0);
            else
                _material.color = originalColor;
        }
    }

}