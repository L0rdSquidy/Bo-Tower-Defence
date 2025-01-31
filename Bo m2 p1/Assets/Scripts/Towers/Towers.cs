using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
public class Towers : MonoBehaviour
{
    public enum TowerState { Idle, Attacking, Cooldown }

    public List<GameObject> enemies;
    private float timeelapsed;
    public bool isInRadius;
    public GameObject Fireball;
    
    [SerializeField] private float cooldown;
    [SerializeField] private float ReductionTime;
    [SerializeField] private float stamina;
    [SerializeField] private bool Barcooldown;
    [SerializeField] private float staminareq;
    [SerializeField] private Animator anims;
    [SerializeField] private bool AttackTrigger = false;
    [SerializeField] private GameObject AttackLocation;
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private GameObject CanvasObject;

    private Canvas canvas;
    public bool HasChosenSub;
    public float TotalLvL;
    public float TotalDmmg;
    private TowerState currentState;
    
    public SubclassType selectedSubclass; 
    
    Vector3 offset = new Vector3(0, 0, 180);

    private void Start() 
    {
        anims = GetComponentInChildren<Animator>();
        canvas = FindAnyObjectByType<Canvas>();
        CanvasObject = canvas.gameObject;
        currentState = TowerState.Idle;
    }

    private void Update() 
    {
        timeelapsed += Time.deltaTime;
        isInRadius = enemies.Count > 0;

        if (isInRadius && timeelapsed >= cooldown && stamina >= 0 && !Barcooldown)
        {
            currentState = TowerState.Attacking;
            anims.Play("attack"); 
            stamina -= 1;
            fire();
            timeelapsed = 0;
        }

        if (selectedSubclass == SubclassType.FireMage)
        {
            cooldown -= ReductionTime;
        }

        stamina = Mathf.Max(stamina, 0);

        if (stamina <= staminareq)
        {
            StartCoroutine(Kiregen());
        }
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

    public void GetTotal(int damage, float ExpMul)
    {
        TotalDmmg = damage * ExpMul;
    }

    private IEnumerator Kiregen()
    {
        currentState = TowerState.Cooldown;
        while (stamina < 30)
        {
            Barcooldown = stamina < 28;
            if (stamina >= 29) 
            currentState = TowerState.Idle;
            stamina++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void fire()
    {
        if (enemies.Count == 0) return;

        Instantiate(Fireball, transform.position, Quaternion.identity, AttackLocation.transform);
        expMultiplier.ExpAdding(20);
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemies[0].transform.position - transform.position);
        transform.rotation *= Quaternion.Euler(offset);
    }
}


public enum SubclassType
{
    None,
    FireMage,
    IceMage,
    ThunderMage
}
