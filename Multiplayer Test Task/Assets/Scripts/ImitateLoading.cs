using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitateLoading : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,-1),250f*Time.deltaTime);
    }
}
