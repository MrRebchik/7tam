using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRegistration : MonoBehaviour
{
    public string Name { get; private set; }
    [SerializeField] private TMP_InputField field;
    [SerializeField] private Image logIn;
    [SerializeField] private GameObject script;
    private void Start()
    {
        logIn.gameObject.SetActive(true);
        Name = string.Empty;
    }
    public bool SetName()
    {
        if (field.text != string.Empty)
        {
            Name = field.text;
            Debug.Log("Зашел под ником " + Name);
            return true;
        }
        else return false;
    }
    public void EnterLobby()
    {
        if (SetName())
        {
            logIn.gameObject.SetActive(false);
            script.gameObject.SetActive(true);
        }
    }
    
}
