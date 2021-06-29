﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] stones;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true)
        {
            float time = Random.Range(0.3f, 0.6f);
            yield return new WaitForSeconds(time);

            int stone = Random.Range(0, stones.Length-1);
            float x = Random.Range(-3,3);
            Vector3 position = new Vector3(x, transform.position.y, 0);

            GameObject newStone = Instantiate(stones[stone], position, Quaternion.identity);
            Destroy(newStone, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
