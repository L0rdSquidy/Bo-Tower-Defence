using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystal_death : MonoBehaviour
{    
    private float CrystalHealth = 10;
    private Wave wave;
    [SerializeField] private GameObject deathScreen;
    public Slider value;
    public Image HealthValue;
    public Color Danger = Color.yellow;
    public Color DangerColor = Color.red;
    public Color DeathColor = Color.red;
    [SerializeField] private Color targetColor;
    public Color normalColor = Color.red;

    private float colorTransitionSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        targetColor = normalColor;
        HealthValue.color = normalColor;
        wave = FindAnyObjectByType<Wave>();
    }
   

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {  
            wave.KillUp();
            CrystalHealth -= 1;
            Destroy(other.gameObject);
            value.value = CrystalHealth;
            if (value.value > 5)
            {
                targetColor = normalColor;
            } else if (value.value > 2)
            {
                targetColor = DangerColor;
            } else if (value.value > 0)
            {
                targetColor = Danger;
            }else
            {
                targetColor = DeathColor;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalHealth == 0)
        {
            deathScreen.SetActive(true);
        }
         if (Input.GetKeyDown(KeyCode.R))
        {
            deathScreen.SetActive(true);
        }
        HealthValue.color = Color.Lerp(HealthValue.color, targetColor, colorTransitionSpeed * Time.deltaTime);
    }
}
