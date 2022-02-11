using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    AudioClip coinPickup;
    UIManager uimanager;

    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uimanager.HideCoinHint();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            uimanager.ShowCoinHint();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    uimanager.HideCoinHint();
                    uimanager.CollectCoin();
                    AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1f);
                    player.hasCoin = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
