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
        if(GetComponentInChildren<ICanBeHeld>() == null)
        {
            g.transform.SetParent(this.transform);
            g.transform.position = this.transform.position;
            GridChanged();
        }
    }

    void AlignHeldObject()
    {
        GetComponentInChildren<ICanBeHeld>()?.MoveTo(this.transform.position);
    }

    public override char GetLetter()
    {
        foreach(Transform child in transform)
        {
            if(child != this.gameObject.transform && child.GetComponent<IHaveLetter>() != null )
            {
                return child.GetComponent<IHaveLetter>().GetLetter();
            }
        }
        return ' ';
    }

    public override void Clear()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<ICanBeHeld>()?.Clear();
        }
        base.Clear();
    }

}
