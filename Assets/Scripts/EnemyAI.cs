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

            agent.destination = player.position;
        }

        void Update()
        {
            /*
            float Range = Vector2.Distance(transform.position, player.transform.position);
            //Vector3 velocity = new Vector3((transform.position.x - Player.transform.dposition.x) * speed, (transform.position.y - Player.transform.position.y) * speed);
            if (Range <= 15f)
            {
                //transform.position = Vector3.MoveTowards(transform.position, Player.position, velocity * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            */

            /*
            Vector2 dist = nextNode - new Vector2(transform.position.x, transform.position.y);
            if(dist.magnitude <= 0.2 && path.Count > 0)
            {
                prevNode = nextNode;
                nextNode = path[0];
            }
            else
            {
                Vector3 target = new Vector3(nextNode.x, nextNode.y, 0);
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }

            Vector2 start = new Vector2(transform.position.x, transform.position.y);
            Vector2 end = new Vector2(player.position.x, player.position.y);
            path = AINavMeshGenerator.pathfinder.FindPath(start, end);
            nextNode = path[0];
            */

            agent.destination = player.position;
        }
    }
}
