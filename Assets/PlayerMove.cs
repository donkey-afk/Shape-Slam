using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{ 
    public static PlayerMove instance;

    private Rigidbody2D player;
    public float speed = 35.0f;
    public float timer; 
    public float timerReset;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timerReset = timer;
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(timer > 0) 
        { 
            timer -= Time.deltaTime;
        } 
        
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
            speed = 110f;
            timer = timerReset;
            }

        if (timer < 1.5)
        {
            speed = 35f;
        }


        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
    
        player.AddForce(direction, ForceMode2D.Force);
    }
    public IEnumerator Knockback(float knockbackduration, float knockbackPower, Transform obj)
    {
        float timer2 = 0;

        while(knockbackduration > timer2)
        {
            timer2 += Time.deltaTime;
            Vector2 direction = (obj.transform.position -  this.transform.position).normalized;
            player.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
}