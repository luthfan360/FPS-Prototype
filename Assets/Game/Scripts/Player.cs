using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed = 3f;
    float gravity = 9.8f;
    [SerializeField]
    GameObject muzzleFlash;
    [SerializeField]
    GameObject hitMarker;
    [SerializeField]
    AudioSource weaponAudio;
    [SerializeField]
    public int currentAmmo;
    [SerializeField]
    public bool hasCoin = false;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    GameObject weapon;
    int maxAmmo = 50;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        currentAmmo = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        CalculateMovement();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0 && weapon.activeSelf)
        {
            muzzleFlash.SetActive(true);

            if (weaponAudio.isPlaying == false)
            {
                weaponAudio.Play();
            }

            currentAmmo-- ;
            
            Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("You hit: " + hitInfo.transform.name);
                Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                Destructable crate = hitInfo.transform.GetComponent<Destructable>();
                if (crate != null)
                {
                    crate.DestroyCrate();
                }
            }
        }
        else
        {
            muzzleFlash.SetActive(false);
            weaponAudio.Stop();
        }
    }

    void CalculateMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0, yInput);
        Vector3 movement = direction * speed;
        movement.y -= gravity;

        movement = transform.transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);

        transform.position = GetComponent<NavMeshAgent>().nextPosition;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2.5f);
        currentAmmo = maxAmmo;
    }

    public void playWinSFX()
    {
        audioSource.Play();
    }

    public void equipWeapon()
    {
        weapon.SetActive(true);
        currentAmmo = maxAmmo;
    }

}
