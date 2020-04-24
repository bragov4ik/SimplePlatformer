using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Color _origColor;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        _origColor = renderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        _origColor = renderer.color;
        Color newColor = _origColor;
        newColor.a = 0.2f;
        renderer.color = newColor;
    }

    public void close()
    {

        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = false;
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = _origColor;
    }
}
