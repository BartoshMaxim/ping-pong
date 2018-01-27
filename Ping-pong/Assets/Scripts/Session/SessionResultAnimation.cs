using Assets.Scripts.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Session
{
    /// <summary>
    /// Session Result Animation(Result scene)
    /// </summary>
    class SessionResultAnimation : MonoBehaviour
    {
        private static string _tag = "SessionResultAnimation";

        private UnityEngine.Logger _logger;

        Text Text;
        private void Start()
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "SessionResultAnimation Start.");
            try
            {
                Text = GetComponent<Text>();
                if (Menu.SessionList == null)
                {
                    Text.text = "No Data";
                    return;
                }
                else
                if (Menu.SessionList.Sessions.Count != 0)
                    Text.text = getLastObjectInformation();
                else
                    Text.text = "No Data";
            }
            catch (System.Exception e)
            {
                _logger.LogException(e);
            }
        }

        /// <summary>
        /// Get info about last session
        /// </summary>
        /// <returns>info about last session</returns>
        private string getLastObjectInformation()
        {
            SessionResult result = Menu.SessionList.Sessions[Menu.SessionList.Sessions.Count - 1];
            string stringResult = String.Format("Session ID: {0}\nsTime int labyrinth: {1}\nGame Started: {2}\nDeath name: {3}",
                result.Id,
                result.SpentTime,
                result.TimeCreated.ToString("G"),
                result.NameDeath);
            return stringResult;
        }
    }
}
