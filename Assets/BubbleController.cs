using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour
{
    public GameObject bubblePrefab; // bubble prefab
    public Transform playerTransform; // player Transform
    public float bubbleOffset = -0.001f; // bubble offset from player

    void Update()
    {
        // check s key press
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateBubble();
        }
    }

    private void CreateBubble()
    {
        // make sure respawn position is above the player
        //Vector3 spawnPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + bubbleOffset, playerTransform.position.z);
        //GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        Vector3 spawnPosition = playerTransform.position + new Vector3(0, bubbleOffset, 0);
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // destroy bubble after 5 seconds
        StartCoroutine(DestroyBubbleAfterDelay(bubble));
    }

    private IEnumerator DestroyBubbleAfterDelay(GameObject bubble)
    {
        Debug.Log("Bubble will disappear in 5 seconds...");
        yield return new WaitForSeconds(5f);
        Debug.Log("Bubble disappeared!");
        Destroy(bubble);
    }

     /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the bubble. Starting countdown...");
            StartCoroutine(DestroyAfterDelay());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player triggered the bubble. Starting countdown...");
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        Debug.Log("Bubble will disappear in 5 seconds...");
        
        yield return new WaitForSeconds(5f);
        
        Debug.Log("Bubble disappeared!");
        Destroy(gameObject);
    }*/
}
