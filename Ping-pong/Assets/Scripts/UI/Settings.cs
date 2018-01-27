
using Assets.Scripts.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Manage Settings scene
    /// </summary>
    class Settings : MonoBehaviour
    {
        private static string _tag = "Settings";

        private UnityEngine.Logger _logger;

        public Text Player1MoveRight;
        public Text Player1MoveLeft;

        public Text Player2MoveRight;
        public Text Player2MoveLeft;

        public Text Player3MoveRight;
        public Text Player3MoveLeft;

        public Text Player4MoveRight;
        public Text Player4MoveLeft;

        private void Start()
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "Settings Start.");
        }

        /// <summary>
        /// Set Player Name with symbols check
        /// </summary>
        public void SetPlayerName()
        {
            _logger.Log((KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveRight.text));
            Menu.UsersMoveKeys.Player1MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveRight.text);
            Menu.UsersMoveKeys.Player1MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveLeft.text);

            Menu.UsersMoveKeys.Player2MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player2MoveRight.text);
            Menu.UsersMoveKeys.Player2MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player2MoveLeft.text);

            Menu.UsersMoveKeys.Player3MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player3MoveRight.text);
            Menu.UsersMoveKeys.Player3MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player3MoveLeft.text);

            Menu.UsersMoveKeys.Player4MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player4MoveRight.text);
            Menu.UsersMoveKeys.Player4MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player4MoveLeft.text);

            _logger.Log(Menu.UsersMoveKeys.Player1MoveRight);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
