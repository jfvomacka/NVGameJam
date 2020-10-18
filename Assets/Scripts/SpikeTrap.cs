﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SpikeTrap : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Game.PlayerMovement p = gameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
                p.Die();
            }
        }
    }
}
