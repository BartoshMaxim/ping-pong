using Assets.Scripts.Logger;
using Assets.Scripts.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Manage Statistics scene
    /// </summary>
    class Statistics : MonoBehaviour
    {
        private static string _tag = "Settings";

        private UnityEngine.Logger _logger;

        /// <summary>
        /// Resuslt statistic
        /// </summary>
        private Text _textResult;
        private void Start()
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "Statistics Start.");

            try
            {
                _textResult = GetComponent<Text>();

                if (File.Exists(Path.Combine(Application.dataPath, "session_list.xml")))
                    _textResult.text = getTable(SessionList.Load().Sessions);
                else
                    _textResult.text = "No data";
            }
            catch (System.Exception e)
            {
                _logger.LogException(e);
            }
        }

        /// <summary>
        /// Conver data from sessionList to string data
        /// </summary>
        /// <param name="sessionResultList">sessionList</param>
        /// <returns>string data</returns>
        private string getTable(List<SessionResult> sessionResultList)
        {
            var sessionList = sessionResultList.OrderByDescending(d => d.TimeCreated);

            string sessionListString = "\tID\t\tTime Created\tSpentTime\tPoints\n";
            foreach (SessionResult sessionResult in sessionList)
            {
                string tab = "\t\t";

                if (sessionResult.Id >= 10 && sessionResult.Id < 100)
                    tab = "\t";
                else if (sessionResult.Id >= 100)
                    tab = " ";

                sessionListString += String.Format("\t{0}" + tab + "{1}\t{2}\t\t\t{3}\n",
                    sessionResult.Id,
                    sessionResult.TimeCreated.ToString("MM/dd hh:mm:ss"),
                    sessionResult.SpentTime.ToString(),
                    sessionResult.Points);
            }
            return sessionListString;
        }

        /// <summary>
        /// Load Menu
        /// </summary>
        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
