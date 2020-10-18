﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MainMenu : MonoBehaviour
    {
        public Dialogue dialogue;

        public void Play()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //SceneManager.LoadScene(1);
            Destroy(gameObject);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
