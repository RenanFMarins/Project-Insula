using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // O objeto que a câmera vai seguir (o boneco)
    public Vector3 offset;        // Distância da câmera em relação ao boneco
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Se quiser que a câmera olhe para o boneco
        // transform.LookAt(target);
    }
}

