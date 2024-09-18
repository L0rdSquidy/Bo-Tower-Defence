using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Color normalColor = Color.black;
    public Color highlightColor = Color.red;

    public Color clicklightColor = Color.red;

    private Color targetColor;
    public float colorTransitionSpeed = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        if (spriteRenderer  != null)
        {
            
            targetColor = normalColor;
            spriteRenderer.color = normalColor;
        }
    }
    void OnMouseEnter()
    {
        targetColor = highlightColor;
    }
    private void OnMouseDown() 
    {
        targetColor = clicklightColor;
    }

    void OnMouseExit()
    {
       targetColor = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorTransitionSpeed * Time.deltaTime);
    }
}
