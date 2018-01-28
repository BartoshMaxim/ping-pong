
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

        public Text ErrorText;

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
            SetInputFields();
        }

        /// <summary>
        /// Set Player Name with symbols check
        /// </summary>
        public void SetPlayerName()
        {
            if (Validate())
            {
                Menu.UsersMoveKeys.Player1MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveRight.text);
                Menu.UsersMoveKeys.Player1MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player1MoveLeft.text);

                Menu.UsersMoveKeys.Player2MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player2MoveRight.text);
                Menu.UsersMoveKeys.Player2MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player2MoveLeft.text);

                Menu.UsersMoveKeys.Player3MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player3MoveRight.text);
                Menu.UsersMoveKeys.Player3MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player3MoveLeft.text);

                Menu.UsersMoveKeys.Player4MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player4MoveRight.text);
                Menu.UsersMoveKeys.Player4MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), Player4MoveLeft.text);
            }
        }

        private void SetInputFields()
        {
            if (Menu.UsersMoveKeys != null)
            {
                Player1MoveRight.text = Menu.UsersMoveKeys.Player1MoveRight.ToString();
                Player1MoveLeft.text = Menu.UsersMoveKeys.Player1MoveLeft.ToString();

                Player2MoveRight.text = Menu.UsersMoveKeys.Player2MoveRight.ToString();
                Player2MoveLeft.text = Menu.UsersMoveKeys.Player2MoveLeft.ToString();

                Player3MoveRight.text = Menu.UsersMoveKeys.Player3MoveRight.ToString();
                Player3MoveLeft.text = Menu.UsersMoveKeys.Player3MoveLeft.ToString();

                Player4MoveRight.text = Menu.UsersMoveKeys.Player4MoveRight.ToString();
                Player4MoveLeft.text = Menu.UsersMoveKeys.Player4MoveLeft.ToString();
            }
        }

        private bool Validate()
        {
            var listOfElements = new List<string>();

            listOfElements.Add(Player1MoveRight.text);
            listOfElements.Add(Player1MoveLeft.text);
            listOfElements.Add(Player2MoveRight.text);
            listOfElements.Add(Player2MoveLeft.text);
            listOfElements.Add(Player3MoveRight.text);
            listOfElements.Add(Player3MoveLeft.text);
            listOfElements.Add(Player4MoveRight.text);
            listOfElements.Add(Player4MoveLeft.text);

            var error = true;

            listOfElements.ForEach(x =>
            {
                if (listOfElements.Count(i => i == x) > 1)
                {
                    error = false;
                    return;
                }
            });

            if (!error)
            {
                ErrorText.text = "Символы не должны повторяться!";
            }
            else
            {
                ErrorText.text = "";
            }

            return error;
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
