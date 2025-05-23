using UnityEngine;
using UnityEngine.SceneManagement; // ✅ Necessário para reiniciar a cena

public class RockBreak : MonoBehaviour
{
    public GameObject fragmentsPrefab; // Prefab com as pedrinhas
    public float breakDelay = 0.05f;   // Pequeno delay para efeito

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se colidiu com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Instancia os fragmentos na posição da pedra maior
            Instantiate(fragmentsPrefab, transform.position + Vector3.up * 0.5f, transform.rotation);

            // Destroi a pedra maior após um pequeno tempo
            Destroy(gameObject, breakDelay);
        }

        // Verifica se colidiu com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reinicia a cena atual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

