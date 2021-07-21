using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity
{
    public int points = 100;
   
   protected override void OnTriggerEnter2D(Collider2D collision)
   {
       if (!collision.GetComponent<Shot>()) return;
       
       GameController. Instance.UpdateScore(points);
       base.OnTriggerEnter2D(collision);
   }
}
