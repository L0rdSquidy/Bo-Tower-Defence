using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
public class Towers : MonoBehaviour
{
    public List<GameObject> enemies;
    private float timeelapsed;
    public bool isInRadius;
    public GameObject Fireball;
    [SerializeField] private float cooldown;
    [SerializeField] private float stamina;
    [SerializeField] private bool Barcooldown;
    [SerializeField] private float staminareq;
    [SerializeField] private Animator anims;
    [SerializeField] private bool AttackTrigger = false;
    [SerializeField] private GameObject AttackLocation;
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private GameObject CanvasObject;

    [SerializeField] private GameObject CharacterSheet;
    private Canvas canvas;
    private GameObject Charasheet;
    [SerializeField] private CharSheet charSheet;
    public bool HasChosenSub;
    public float TotalLvL;
    public string CharSubC;
    public float TotalDmmg;
    public bool SheetIsActive;
    private int SheetSpawned = 0;
    // [SerializeField] TowerExp Exp;
    Vector3 offset = new Vector3(0, 0, 180);
    private void Start() 
    {
        // expMultiplier = GetComponent<TowerExp>();
        anims = GetComponentInChildren<Animator>();
        canvas = FindAnyObjectByType<Canvas>();
        CanvasObject = canvas.gameObject;
        // Exp = Exp.GetComponent<TowerExp>();
        TotalLvL = expMultiplier.levels;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.CompareTag("Enemy"))
        {
        enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
        enemies.Remove(other.gameObject);
        }
    }
    public void GetTotal(float TotalDammage)
    {
        TotalDmmg = TotalDammage;
    }
    // private void OnMouseDown() 
    // {
        
    //     if (!SheetIsActive)
    //     {
    //         if (SheetSpawned == 0)
    //         {
    //             SheetSpawned++;
    //         Charasheet = Instantiate(CharacterSheet, new Vector3(900, 500,0), Quaternion.identity, CanvasObject.transform);
    //         charSheet = Charasheet.GetComponent<CharSheet>();
    //         } else
    //         {
    //             Charasheet.SetActive(true);
    //         } 
    //         StartCoroutine(Characsheet());
    //         SheetIsActive = true;
            
    //     }
    //     if (!Charasheet.active)
    //     {
    //         SheetIsActive = false;
    //     }
        
        
    // }

    

    // IEnumerator Characsheet()
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     charSheet.CharDmmg.text = "" + TotalDmmg;
    //     charSheet.CharLevel.text = "" + TotalLvL;
    //     if (!HasChosenSub)
    //     {
    //         charSheet.CharAff.text = "Null";
    //         charSheet.CharSubC.text = "";
    //     }
    // }

    private void Update() 
    {
        timeelapsed += Time.deltaTime;
        isInRadius = enemies.Count > 0;
        if (timeelapsed == 0)
        {
            anims.Play("attack");
        }
        if (isInRadius && timeelapsed >= cooldown && stamina >= 0 && !Barcooldown)
        {
            anims.Play("attack"); 
            stamina -= 1;
            fire();
            timeelapsed = 0;
        }
        
        stamina = Mathf.Max(stamina, 0);

        if (stamina <= staminareq)
        {
            StartCoroutine(Kiregen());
        }
        
    }

    private IEnumerator Kiregen()
    {
        while (stamina < 30)
        {
            if (stamina < 28)
            {
                Barcooldown = true;
            } else if (stamina >= 29)
            {
                Barcooldown = false;
            }
        stamina++;
        yield return new WaitForSeconds(0.2f);
        }
    }
    public void fire()
    {
        // anims.Play("attack");
        Instantiate(Fireball, transform.position, Quaternion.identity, AttackLocation.transform);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemies[0].transform.position - transform.position);
        transform.rotation *= Quaternion.Euler(offset);
    }
}
