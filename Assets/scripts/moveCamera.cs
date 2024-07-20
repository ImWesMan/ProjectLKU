using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
     public Transform player;
     public Vector3 offset;
  
  void Update () 
  {
    if(PlayerMovement.facingRight == true)
    {
      transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
    if(PlayerMovement.facingRight == false)
    {
      transform.position = new Vector3 (player.position.x - offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
  }
}
