using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDPH : MonoBehaviour {
    public delegate void DamageDPHAction(GameObject player);
    public static event DamageDPHAction OnDamagePlayer;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (OnDamagePlayer != null)
            {
                OnDamagePlayer(collider.gameObject);
            }
        }
    }
}