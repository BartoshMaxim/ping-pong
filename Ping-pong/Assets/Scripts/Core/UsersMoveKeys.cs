using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class UsersMoveKeys
    {
        public KeyCode Player1MoveRight { get; set; }
        public KeyCode Player1MoveLeft { get; set; }

        public KeyCode Player2MoveRight { get; set; }
        public KeyCode Player2MoveLeft { get; set; }

        public KeyCode Player3MoveRight { get; set; }
        public KeyCode Player3MoveLeft { get; set; }

        public KeyCode Player4MoveRight { get; set; }
        public KeyCode Player4MoveLeft { get; set; }

        public UsersMoveKeys()
        {
            Player1MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), "LeftArrow");
            Player1MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), "RightArrow");

            Player2MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Q");
            Player2MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), "E");

            Player3MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), "A");
            Player3MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), "D");

            Player4MoveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Z");
            Player4MoveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), "C");
        }
    }
}
