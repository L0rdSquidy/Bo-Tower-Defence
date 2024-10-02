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
    private float TimeCheck;
    // Start is called before the first frame update
    void Start()
    {
        TimeCheck += Time.deltaTime;
        spriteRenderer  = GetComponent<SpriteRenderer>();
        if (spriteRenderer  != null)
        {
            
            targetColor = normalColor;
            spriteRenderer.color = normalColor;
        }   

        ToDeath();
    Invoke(nameof(ToDeath), 3f);

    }

    private void ToDeath()
    {
        targetColor = highlightColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorTransitionSpeed * Time.deltaTime);
        
    }

    private void OnMouseDown() 
    {
        SceneManager.LoadScene(0);
    }

    private void ToGameStart()
    {
        SceneManager.LoadScene(0);
    }
}
