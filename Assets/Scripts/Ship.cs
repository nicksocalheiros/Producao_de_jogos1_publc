using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : GameEntity
{
    [SerializeField] private Transform cannon;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private Animator anim;

    private bool shooting;
    public Spawn spawn {get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(
            new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        var CameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y
        );

        Vector3 position = transform.position;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        anim.SetFloat("horizontal", x);

        position.x += x * 5.0f * Time.deltaTime;
        position.y += y * 5.0f * Time.deltaTime;

        transform.position = position;

        float clampX = Mathf.Clamp(transform.position.x, CameraRect.xMin, CameraRect.xMax);
        float clampY = Mathf.Clamp(transform.position.y, CameraRect.yMin, CameraRect.yMax);

        transform.position = new Vector3(clampX, clampY, transform.position.z);

        if (Input.GetKey(KeyCode.Space)) Shot();

        if(Input.GetKey(KeyCode.Alpha0)) laser = lasers[0];
        if(Input.GetKey(KeyCode.Alpha1)) laser = lasers[1];
        if(Input.GetKey(KeyCode.Alpha2)) laser = lasers[2];
        if(Input.GetKey(KeyCode.Alpha3)) laser = lasers[3];
        if(Input.GetKey(KeyCode.Alpha4)) laser = lasers[4];
        if(Input.GetKey(KeyCode.Alpha5)) laser = lasers[5];
        if(Input.GetKey(KeyCode.Alpha6)) laser = lasers[6];
        if(Input.GetKey(KeyCode.Alpha7)) laser = lasers[7];
        if(Input.GetKey(KeyCode.Alpha8)) laser = lasers[8];
        if(Input.GetKey(KeyCode.Alpha9)) laser = lasers[9];
    }

    void Shot ()
    {
        if (shooting) return;
        shooting = true;

        GameObject newShot = Instantiate(laser, cannon.position, cannon.rotation);
        newShot.TryGetComponent(out Shot shot);
        StartCoroutine(Cooldown(shot.cooldown));
    }

    IEnumerator Cooldown (float time)
    {
        yield return new WaitForSeconds (time);
        shooting = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        spawn.SpawnShip();
        base.OnTriggerEnter2D(collision);
    }
}
