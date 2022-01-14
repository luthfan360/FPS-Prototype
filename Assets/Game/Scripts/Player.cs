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
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("You hit: " + hitInfo.transform.name);
            }
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
}
