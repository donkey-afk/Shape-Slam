using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Move : MonoBehaviour
{
    public static P2Move instance;

    private Rigidbody2D player2;
    public float speed2 = 35.0f;
    public float timer3;
    public float timerReset3;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timerReset3 = timer3;
        player2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timer3 > 0)
        {
            timer3 -= Time.deltaTime;
        }

        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            speed2 = 110f;
            timer3 = timerReset3;
        }

        if (timer3 < 1.5)
        {
            speed2 = 35f;
        }


        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")) * speed2;

        player2.AddForce(direction, ForceMode2D.Force);
    }
    public IEnumerator Knockback(float knockbackduration, float knockbackPower, Transform obj)
    {
        float timer2 = 0;

        while (knockbackduration > timer2)
        {
            timer2 += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            player2.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
}