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

        private UnityEngine.AI.NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            speed = 2.5f;
            player = GameObject.FindGameObjectWithTag("Player").transform;

            agent.destination = transform.position;

            GameManager.instance.AddEnemyToList(this);
        }

        void Update()
        {

            if(GameManager.instance.GameIsOver())
            {
                return;
            }

            float dist = (player.position - transform.position).magnitude;
            if(dist <= 8f)
            {
                agent.destination = player.position;
            }
            
        }
    }
}
