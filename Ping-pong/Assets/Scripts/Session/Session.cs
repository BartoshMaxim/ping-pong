using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Logger;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Session
{
    /// <summary>
    /// Current session
    /// </summary>
    public class Session : MonoBehaviour, ISession
    {
        public static readonly string sessionGameObjectName = "session";

        private static string _tag = "Session";

        private UnityEngine.Logger _logger;

        private DateTime timeCreate;

        public bool SessionStart { get; set; }

        private void Start()
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "Session Start.");
            timeCreate = DateTime.Now;

            SessionStart = false;
        }

        private void Update()
        {
            //exit
            if (Input.GetKey(KeyCode.Escape))
            {
                Exit("Escape");
            }
        }

        public void Exit(string nameDeath)
        {
            SaveResults(nameDeath);
        }

        /// <summary>
        /// Save Results and start new scene
        /// </summary>
        public void SaveResults(string nameDeath)
        {
            try
            {
                var spendTime = DateTime.Now -timeCreate;

                Debug.Log("TimeCreate " + timeCreate);
                Debug.Log("Spend " + spendTime.ToString());
                Debug.Log("Death " + nameDeath);

                SessionResult sessionResult = new SessionResult(timeCreate, spendTime, nameDeath, 0);
                Menu.SessionList.Sessions.Add(sessionResult);
                Menu.SessionList.Save();
            }
            catch (System.Exception e)
            {
                _logger.LogException(e);
            }
            SceneManager.LoadScene("Result");
        }
    }
}
