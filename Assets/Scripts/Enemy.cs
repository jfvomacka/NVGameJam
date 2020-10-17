using UnityEngine;
using System.Collections;

namespace Game
{
    //Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
    public class Enemy : MonoBehaviour
    {
        //public int playerDamage; 							//The amount of food points to subtract from the player when attacking.
        //public AudioClip attackSound1;						//First of two audio clips to play when attacking the player.
        //public AudioClip attackSound2;						//Second of two audio clips to play when attacking the player.


        private Animator animator;                          //Variable of type Animator to store a reference to the enemy's Animator component.
        private Transform target;                           //Transform to attempt to move toward each turn.

        private BoxCollider2D collider = null;

        public float speed;
        private Vector2 direction;

        //Start overrides the virtual Start function of the base class.
        void Start()
        {

            speed = 3;

            //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
            //This allows the GameManager to issue movement commands.
            GameManager.instance.AddEnemyToList(this);

            //Get and store a reference to the attached Animator component.
            animator = GetComponent<Animator>();

            //Find the Player GameObject using it's tag and store a reference to its transform component.
            target = GameObject.FindGameObjectWithTag("Player").transform;

            collider = gameObject.AddComponent<BoxCollider2D>();

        }

        void Update()
        {
            MoveEnemy();
            transform.Translate(direction * speed * Time.deltaTime);
        }

        //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
        public void MoveEnemy()
        {
            Vector3 targetDirection = transform.position - target.position;

            Debug.Log("Target direction = (" + targetDirection.x + ", " + targetDirection.y + ", " + targetDirection.z + ")");

            direction.x = targetDirection.normalized.x;
            direction.y = targetDirection.normalized.y;
        }
    }
}
