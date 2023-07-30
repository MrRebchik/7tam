using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = "Победил игрок" + PhotonNetwork.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
