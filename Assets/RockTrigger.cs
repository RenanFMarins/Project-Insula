using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 5f;
    private bool hasFallen = false;

    public GameObject smallRocksPrefab; // Prefab das pedrinhas
    public Transform spawnPoint; // Onde elas vão aparecer

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!hasFallen && Vector3.Distance(player.position, transform.position) < triggerDistance)
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasFallen && collision.gameObject.CompareTag("Ground"))
        {
            hasFallen = true;

            // Instanciar as pedrinhas
            Instantiate(smallRocksPrefab, spawnPoint.position, Quaternion.identity);

            // Desativar a pedra grande
            gameObject.SetActive(false);
        }
    }
}

