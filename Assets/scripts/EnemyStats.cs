using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float attackSpeed;
    public GameObject enemy;
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(enemy);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
       
        
    }
    void takeDamage()
    {

    }

}
