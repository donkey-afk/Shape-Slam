using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walls : MonoBehaviour
{
    public float knockbackPower = 200;
    public float knockbackduration = 1;
    private GameObject Ball;
    private GameObject Goal1;
    private void Start()
    {
        Goal1 = GameObject.FindGameObjectWithTag("Goal1");
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }
    private void OnCollisionEnter(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            StartCoroutine(PlayerMove.instance.Knockback(knockbackPower, knockbackduration, this.transform));
        }
    }
    private void Update()
    {
        if (Ball.transform.position.x <= -36 && Ball.transform.position.x >= -37 && Ball.transform.position.y >= -4 && Ball.transform.position.y <= 4)
        {
            SceneManager.LoadScene(1);
        }
        if( Ball.transform.position.x >= 36 && Ball.transform.position.x <= 37 && Ball.transform.position.y >= -4 && Ball.transform.position.y <= 4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
