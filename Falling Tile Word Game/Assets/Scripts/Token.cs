using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(DragDrop))]
public class Token : MonoBehaviour, ICanBeHeld
{
    public bool BeingHeld { get; private set; }
    private DragDrop dragDrop;
    private Transform birthParent;

    void Awake()
    {
        dragDrop = GetComponent<DragDrop>();
        dragDrop.OnDragStateChanged += OnDragStateChanged;
        GameManager.OnGameStateChanged += GameStateChanged;
        if(transform.parent != null)
        {
            birthParent = transform.parent;
        }
    }

    void OnDragStateChanged(object sender, DragDrop.OnDragStateChangedEventArgs args)
    {
        if(!args.beingDragged)
        {
            CheckForHolder();
        }
    }
        
    private void GameStateChanged(GameState newState)
    {
        Destroy(this.gameObject);
    }

    void CheckForHolder()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, Vector2.left, (float) 0.0001);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.transform.gameObject.TryGetComponent(out ICanHold holder))
            {
                holder.Hold(this.gameObject);
                return;
            }
        }
        this.transform.SetParent(birthParent);
    }

    public void BeHeldBy(GameObject holder)
    {
        this.transform.SetParent(holder.transform);
    }

    public void Clear()
    {
        Destroy(this.gameObject);
    }

    public void MoveTo(Vector3 position)
    {
        if(!GetComponent<DragDrop>().BeingDragged && (position - this.transform.position).magnitude > 0.01f)
        {
            //this.transform.position = position;
            transform.DOMove(position, 0.15f);
        }
    }
    
    void OnDestroy()
    {
        GetComponent<DragDrop>().OnDragStateChanged -= OnDragStateChanged;
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

}
