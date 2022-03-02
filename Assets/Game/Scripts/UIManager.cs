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
    [SerializeField]
    Text buyWeaponHint;
    [SerializeField]
    Text noCoinWarning;
    
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

    public void SpendCoin()
    {
        coinImage.SetActive(false);
    }

    public void ShowCoinHint()
    {
        coinHint.gameObject.SetActive(true);
    }

    public void HideCoinHint()
    {
        coinHint.gameObject.SetActive(false);
    }

    public void ShowWeaponHint()
    {
        buyWeaponHint.gameObject.SetActive(true);
    }

    public void HideWeaponHint()
    {
        buyWeaponHint.gameObject.SetActive(false);
    }

    public IEnumerator ShowNoCoinWarning()
    {
        noCoinWarning.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noCoinWarning.gameObject.SetActive(false);
    }
}
