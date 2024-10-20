using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private List<EnemyPathFinding> Enemies;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Enemies.Add(other.GetComponent<EnemyPathFinding>());
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].speed *= 0.5f;
                Enemies[i].IsSlowedDown = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Enemies.Remove(other.GetComponent<EnemyPathFinding>());
        }
    }
}
