using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Session
{
    NotRegistered = 0,
    Registered = 1
}
public class PlayerRegistration : MonoBehaviourPunCallbacks
{
    public string Name { get; private set; }
    [SerializeField] private TMP_InputField field;
    [SerializeField] private Image logIn;
    [SerializeField] private GameObject script;
    private void Start()
    {
        //if(PlayerPrefs.GetInt("IsRegistered") == (int)Session.NotRegistered)
        //{
            logIn.gameObject.SetActive(true);
            Name = string.Empty;
        //}
        //else
        //{
        //    logIn.gameObject.SetActive(false);
        //}
    }
    public bool SetName()
    {
        if (field.text != string.Empty)
        {
            Name = field.text;
            PlayerPrefs.SetString("name", Name);
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
            script.SetActive(true);
        }
    }
    
    
}
