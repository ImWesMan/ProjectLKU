using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    float health;
    public static bool dead = false;
    public GameObject player;
    public static string playerName = "Player";
    void Update()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().health;
        if(dead == false)
        {
        checkForDeath();
        }
    }

    private void checkForDeath()
    {
          if(health <= 0)
        {
            dead = true;
            PlayerMovement.facingRight = true;
            StartCoroutine(deathSequence());
            Destroy(player);
        }
    }
    
    private IEnumerator deathSequence()
    {
        Debug.Log("You Are Dead");
        yield return new WaitForSeconds(4);
        toMainMenu();
    }

    private void toMainMenu()
    {
        dead = false;
        SceneManager.LoadScene("Main Menu");
    }
}
