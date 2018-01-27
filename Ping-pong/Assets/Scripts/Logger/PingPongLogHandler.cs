using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Logger
{
    /// <summary>
    /// Custom LogHandler
    /// </summary>
    public class PingPongLogHandler: ILogHandler
    {
        public void LogException(System.Exception exception, UnityEngine.Object conKeyKode)
        {
            Debug.unityLogger.LogException(exception, conKeyKode);
        }

        public void LogFormat(LogType logType, UnityEngine.Object conKeyKode, string format, params object[] args)
        {
            Debug.unityLogger.logHandler.LogFormat(logType, conKeyKode, format, args);
        }
    }
}
