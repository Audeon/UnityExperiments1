using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    public event Action OnPlayerDeath;

    private float screenHalfWidthInWorldUnits;
    private float startTime;
    public static float survivalTime;
    private Rigidbody myRigidBody;
    private float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize; //+ halfPlayerWidth;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        velocity = inputX * speed;
        float halfPlayerWidth = transform.localScale.x / 2;
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));

        if (transform.position.x + halfPlayerWidth < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x - halfPlayerWidth > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
  void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "rock")
        {
            // print("Hit Rock.");
            OnPlayerDeath();
            Destroy(gameObject);
            survivalTime = Time.time - startTime;
        }
    }
}
