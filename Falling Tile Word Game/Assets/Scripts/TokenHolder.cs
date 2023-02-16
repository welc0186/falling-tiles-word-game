using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenHolder : GridPiece, ICanHold
{
    
    void Update()
    {
        AlignHeldObject();
    }

    public void Hold(GameObject g)
    {
        if(GetComponentInChildren<ICanBeHeld>() == null && g.TryGetComponent(out ICanBeHeld holdee))
        {
            holdee.BeHeldBy(this.gameObject);
            GridChanged();
        }
    }

    void AlignHeldObject()
    {
        GetComponentInChildren<ICanBeHeld>()?.MoveTo(this.transform.position);
    }

}
