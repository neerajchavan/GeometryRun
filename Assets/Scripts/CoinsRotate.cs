using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotate : MonoBehaviour
{
    public Transform coinsrotate;
   

    // Update is called once per frame
    void Update()
    {
        coinsrotate.transform.Rotate(0,-3,0);  
    }
}
