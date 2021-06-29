using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]private float speed = 5;
    public float cooldown = 0.1f;
    public float hitPoints = 1;
    [SerializeField]private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 2);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
