using Assets.Scripts.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.Session
{
    /// <summary>
    /// Session Result
    /// </summary>
    public class SessionResult
    {
        [XmlIgnore]
        private static string _tag = "SessionResult";

        [XmlIgnore]
        private UnityEngine.Logger _logger;

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement(DataType = "dateTime")]
        public DateTime TimeCreated { get; set; }

        public string SpentTime { get; set; }

        public string NameDeath { get; set; }

        public SessionResult(DateTime timeCreated, TimeSpan spentTime, string nameDeath)
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "SessionResult Create.");
            TimeCreated = timeCreated;
            NameDeath = nameDeath;
            if (Menu.SessionList == null)
                Id = 0;
            else
                Id = Menu.SessionList.Sessions.Count;
            SpentTime = spentTime.Minutes + ":" + spentTime.Seconds;
        }

        public SessionResult()
        {
            _logger = new UnityEngine.Logger(new PingPongLogHandler());
            _logger.Log(_tag, "SessionResult Create.");
        }
    }
}
