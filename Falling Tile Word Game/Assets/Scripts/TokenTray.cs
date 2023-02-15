using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenTray : MonoBehaviour
{
    [SerializeField] private float tokenSpacing;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AlignTokens();
    }

    void AlignTokens()
    {
        List<GameObject> holdables = new List<GameObject>();
        foreach(Transform childTransform in transform)
        {
            if(childTransform.gameObject.GetComponent<ICanBeHeld>() != null)
            {
                holdables.Add(childTransform.gameObject);
            }
        }

        //Sort tokens by x position
        holdables.Sort((x, y) => x.gameObject.transform.position.x.CompareTo(y.gameObject.transform.position.x));

        float pos = tokenSpacing / 2;
        foreach(GameObject holdable in holdables)
        {
            if(!holdable.GetComponent<DragDrop>().BeingDragged)
            {
                float yPos = this.transform.position.y;
                float width = spriteRenderer.bounds.size.x;
                float xPos = this.transform.position.x + - width/2 + pos;
                holdable.GetComponent<ICanBeHeld>()?.MoveTo(new Vector3(xPos, yPos, 0));
            }
            pos += tokenSpacing;
        }
    }

}
