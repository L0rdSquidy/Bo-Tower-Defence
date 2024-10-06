using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public Color normalColor = Color.black;
    public Color highlightColor = Color.black;
    private SpriteRenderer spriteRenderer;
    private Color targetColor;
    public float colorTransitionSpeed = 1f;
    private float timeelapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        if (spriteRenderer  != null)
        {
            
            targetColor = normalColor;
            spriteRenderer.color = normalColor;
        }   
        ToDeath();
    }

    private void ToDeath()
    {
        targetColor = highlightColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed >= 3)
        {
            SceneManager.LoadScene(0);
        }
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorTransitionSpeed * Time.deltaTime);
        
    }

    private void OnMouseDown() 
    {
        SceneManager.LoadScene(0);
    }
}
