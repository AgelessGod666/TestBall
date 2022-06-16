using System;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MonoBehaviours
{
    public class Input : MonoBehaviour, IInputInterface, IPointerClickHandler
    {
        public event Action OnClicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}