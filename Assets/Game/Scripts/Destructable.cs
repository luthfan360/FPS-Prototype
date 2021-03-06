using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    GameObject destroyedCrate;

    public void DestroyCrate()
    {
        Instantiate(destroyedCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
