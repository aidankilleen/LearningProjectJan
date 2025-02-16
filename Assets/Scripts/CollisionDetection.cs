using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public InventoryManager inventoryManager;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {

        if (gameObject.CompareTag("Gate") && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit gate");

            // check if the player has the key in the inventory
            inventoryManager.items.ForEach(item =>
            {
                if (item.name == "Key")
                {
                    Debug.Log("Player has the key");
                    meshRenderer.material.color = Color.yellow;
                    gameObject.SetActive(false);
                }
            }); 



        } else if (other.gameObject.CompareTag("Player"))
        {
            // a wall was hit
            Debug.Log("Wall hit " + other.gameObject.name);

            meshRenderer.material.color = Color.red;
        }
                
    }
}
