using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float maxhealth;
    [SerializeField] public float damage;
    [SerializeField] public string name;
    public Slider slider;
    public TMP_Text healthText;
    public TMP_Text nameText;
    public GameObject player;
    public AudioSource hit;
    float time;

    void Start()
    {
       healthText.text = health  + " / " +  maxhealth;
       nameText.text = GameControl.playerName;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "enemy")
        {
            hit.time = 0.2f;
            hit.Play();
            Debug.Log("Collision detected losing health");
            health = health - GameObject.FindWithTag("enemy").GetComponent<EnemyStats>().damage;
            slider.value = 1.0f - health/maxhealth;
            healthText.text = health  + " / " +  maxhealth;
            
        }
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        time += Time.deltaTime;
        if(time >= GameObject.FindWithTag("enemy").GetComponent<EnemyStats>().attackSpeed)
        {
            hit.time = 0.2f;
            hit.Play();
            Debug.Log("Collision stayed losing health");
             health = health - GameObject.FindWithTag("enemy").GetComponent<EnemyStats>().damage;
            slider.value = 1.0f - health/maxhealth;
            healthText.text = health  + " / " +  maxhealth;
            time = 0f;
        }
        
    }

    private void onCollisionExit(Collision2D other)
        {
            time = 0.0f;
        }
    }

