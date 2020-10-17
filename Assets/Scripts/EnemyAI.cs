using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAI : MonoBehaviour
    {
        public float speed;
        public Transform player;
        private Vector2 direction;

        void Start()
        {
            speed = 2.5f;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            float Range = Vector2.Distance(transform.position, player.transform.position);
            //Vector3 velocity = new Vector3((transform.position.x - Player.transform.position.x) * speed, (transform.position.y - Player.transform.position.y) * speed);
            if (Range <= 15f)
            {
                //transform.position = Vector3.MoveTowards(transform.position, Player.position, velocity * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
