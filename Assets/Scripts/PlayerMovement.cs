using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {

        public float speed;
        private Vector2 direction;
        private bool teleport;
        private bool teleportedLastFrame;
        private const float TELEPORT_DISTANCE = 3.0f;
        private float teleportCooldown;

        private Animator animator;
        private BoxCollider2D collider = null;

        // Start is called before the first frame update
        void Start()
        {
            speed = 3;
            teleport = false;
            teleportedLastFrame = false;
            teleportCooldown = 3f;

            transform.localScale = new Vector3(2, 2, 2);
            transform.position = new Vector3(0, 0, -1);

            animator = GetComponent<Animator>();
            collider = gameObject.AddComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            TakeInput();
        
            if(teleport && !teleportedLastFrame && (teleportCooldown >= 2f))
            {
                MoveTeleport();
                teleport = false;
                teleportCooldown = 0f;
            }
            else
            {
                Move();
            }

            teleportedLastFrame = teleport;
            teleportCooldown += Time.deltaTime;

            SetAnimation();
        }

        private void Move()
        {
            transform.Translate(direction * speed * Time.deltaTime);

            /*
            List<Enemy> enemies = GameManager.instance.GetEnemies();
            for(int i = 0; i < enemies.Count; i++)
            {
            
            }
            */
        }

        private void MoveTeleport()
        {
        
            transform.Translate(direction.normalized * TELEPORT_DISTANCE);
        }

    

        private void TakeInput()
        {
            direction = Vector2.zero;

            if(Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }
            if(Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }
            if(Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }
            if(Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }

            teleport = Input.GetKey(KeyCode.Space);
        }

        private void SetAnimation()
        {
            animator.SetFloat("xDir", direction.x);
            animator.SetFloat("yDir", direction.y);
        } 
    }
}
