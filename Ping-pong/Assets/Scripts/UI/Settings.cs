
using Assets.Scripts.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public InputField Player1MoveRight;
        public InputField Player1MoveLeft;

        public InputField Player2MoveRight;
        public InputField Player2MoveLeft;

        public InputField Player3MoveRight;
        public InputField Player3MoveLeft;

        public InputField Player4MoveRight;
        public InputField Player4MoveLeft;

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
            _logger.Log( Player1MoveRight.text);
            _logger.Log((KeyCode)Enum.Parse(typeof(KeyCode), Player1MoveRight.text));
            KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveRight.text);
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

        public void OnChanged(string field)
        {
            
        }
    }
}
