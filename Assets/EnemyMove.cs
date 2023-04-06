using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

    public Transform Target;
    private GameObject Enemy;
    private GameObject Ball;
    private float Range;
    public float Speed;


    // Use this for initialization
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 velocity = new Vector2((transform.position.x - Ball.transform.position.x) * Speed, (transform.position.y - Ball.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
    }
}