using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    
    public bool Draggable;
    public bool BeingDragged { get; private set; }

    public event EventHandler<OnDragStateChangedEventArgs> OnDragStateChanged;
    public class OnDragStateChangedEventArgs : EventArgs {
        public bool beingDragged;
    }
    
    void Awake()
    {
        Draggable = true;
        BeingDragged = false;
    }

    void Update()
    {
        if(BeingDragged)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if(Draggable)
        {
            BeingDragged = Draggable;
            DragStateChanged();
        }
    }

    private void OnMouseUp()
    {
        if(!BeingDragged)
        {
            return;
        }
        BeingDragged = false;
        DragStateChanged();
    }

    void DragStateChanged()
    {
        OnDragStateChanged?.Invoke(this, new OnDragStateChangedEventArgs { beingDragged = BeingDragged });
    }

}