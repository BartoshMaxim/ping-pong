using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Session
{
    public interface ISession
    {
        bool SessionStart { get; set; }


        void Exit(string nameDeath);

        /// <summary>
        /// Save Results and start new scene
        /// </summary>
        void SaveResults(string nameDeath);
    }
}
