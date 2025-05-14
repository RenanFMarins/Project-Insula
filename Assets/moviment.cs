using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Apenas -1, 0 ou 1
        movement = new Vector3(moveInput, 0f, 0f);

        // Flip do personagem
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); // Olha pra direita
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); // Olha pra esquerda
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, 0f);
    }
}

