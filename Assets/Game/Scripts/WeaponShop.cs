using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Press "E" to buy a Weapon
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                //check player nya punya coin atau tidak
                //kalo punya coin, coin nya akan diambil
                //player dapat weapon
                //play sound effect

                //kalau tidak ada coin
                //munculkan message "you don't have a coin"
            }
        }
    }
}
