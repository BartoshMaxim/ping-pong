using Assets.Scripts.Logger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFieldManager : MonoBehaviour
{
    private InputField inputField;
    // Use this for initialization
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void OnGUI()
    {

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {

            if (Input.GetKey(vKey) && inputField.IsActive() && inputField.isFocused)
            {
                if (!vKey.ToString().Equals("Mouse0") && !vKey.ToString().Equals("Mouse1"))
                {
                    inputField.text = vKey.ToString();
                }
            }
        }
    }
}