using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class Test : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(ButtonClick);
        }

        private void ButtonClick()
        {
            var player = FindObjectOfType<Player>();
            Debug.Log(player.Data.health);
            
            DataContainer.SavePlayerData();
            SceneManager.LoadScene(Scenes.Level1);
        }
    }
}
