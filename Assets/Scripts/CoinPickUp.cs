using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public Transform coinEffect;
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManagers.coinAmmount += 1;
            Transform effect = (Transform)Instantiate(coinEffect, transform.position, transform.rotation);
            //Destroy(effect.gameObject, 3);
            Destroy(gameObject);
        }
    }
}
