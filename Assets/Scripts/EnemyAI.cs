using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public Transform Player;
    private Vector2 direction;

    void Start () {
        speed = 2.5f;
        Player = GameObject.FindGameObjectWithTag ("Player");
    }
    
    void Update () {
        Range = Vector2.Distance (transform.position, Player.transform.position);
        Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * speed, (transform.position.y - Player.transform.position.y) * speed);
        if (Range <= 15f) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
        }
    }
}

