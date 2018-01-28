using Assets.Scripts.Core;
using Assets.Scripts.Logger;
using Assets.Scripts.Session;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Start menu
/// </summary>
public class Menu : MonoBehaviour
{

    private static string _tag = "Menu";

    private UnityEngine.Logger _logger;

    private static SessionList _sessionList;

    public static SessionList SessionList
    {
        get
        {
            if (_sessionList == null)
            {
                _sessionList = new SessionList();
            }
            return _sessionList;
        }
        set
        {
            _sessionList = value;
        }
    }

    private static UsersMoveKeys _usersMoveKeys;

    public static UsersMoveKeys UsersMoveKeys
    {
        get
        {
            if (_usersMoveKeys == null)
            {
                _usersMoveKeys = new UsersMoveKeys();
            }
            return _usersMoveKeys;
        }
        set
        {
            _usersMoveKeys = value;
        }
    }



    private void Start()
    {
        _logger = new UnityEngine.Logger(new PingPongLogHandler());
        _logger.Log(_tag, "SessionResultAnimation Start.");
        UsersMoveKeys = new UsersMoveKeys();
        try
        {
            if (File.Exists(Path.Combine(Application.dataPath, "session_list.xml")))
                SessionList = SessionList.Load();//read data from xml
            else
                SessionList = new SessionList();
        }
        catch (System.Exception e)
        {
            _logger.LogException(e);
        }
    }

    /// <summary>
    /// Load Labyrinth
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("111");
    }

    /// <summary>
    /// Load Settings
    /// </summary>
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    /// <summary>
    /// Load Statistics
    /// </summary>
    public void Statistics()
    {
        SceneManager.LoadScene("Statistics");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Load Menu
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
