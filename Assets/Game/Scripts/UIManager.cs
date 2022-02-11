using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Player player;
    [SerializeField]
    Text ammoText;
    [SerializeField]
    Text coinHint;
    [SerializeField]
    GameObject coinImage;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "AMMO: " + player.currentAmmo;
    }

    public void CollectCoin()
    {
        coinImage.SetActive(true);
    }

    public void ShowCoinHint()
    {
        coinHint.gameObject.SetActive(true);
    }

    public void HideCoinHint()
    {
        coinHint.gameObject.SetActive(false);
    }
}
