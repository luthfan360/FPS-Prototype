using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    UIManager uimanager;

    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            uimanager.ShowWeaponHint();
            Player player = other.GetComponent<Player>();
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.hasCoin == true)
                {
                    player.hasCoin = false;
                    uimanager.SpendCoin();
                    player.playWinSFX();
                    player.equipWeapon();
                }
                else
                {
                    StartCoroutine(uimanager.ShowNoCoinWarning());
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uimanager.HideWeaponHint();
        }
    }
}
