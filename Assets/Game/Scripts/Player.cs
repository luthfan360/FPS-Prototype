using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed = 3f;
    float gravity = 9.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0, yInput);
        Vector3 movement = direction * speed;
        movement.y -= gravity;
        controller.Move(movement * Time.deltaTime);
    }
}
