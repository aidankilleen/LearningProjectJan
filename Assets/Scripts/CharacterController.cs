using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController : MonoBehaviour
{
    public float speed = 0f;
    public float rotationSpeed = 100.0f;
    public float acceleration = 5.0f;
    public float deceleration = 5.0f;

    private Rigidbody _rb;
    private Animator _animator;


    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();   
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;//   (0, 0, speed);

        inventoryManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration * Time.deltaTime;

        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= deceleration * Time.deltaTime;
        } else
        {
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = transform.forward * speed;
        _rb.velocity = velocity;

        _animator.SetFloat("velocity", velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InventoryItem"))
        {
            Debug.Log("hit an inventory item");

            //inventoryManager.items.Add(new Item { 
            //    name = other.gameObject.name, 
            //    description = "Some Description",
            //    obj = other.gameObject
            //});
            inventoryManager.items.Add(new Item { name = other.name });

            other.gameObject.SetActive(false);
        }
    }

}
