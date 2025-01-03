using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime = 3f; // Time before deactivation

    void OnEnable()
    {
        Invoke("Deactivate", lifetime);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke(); // Ensure no pending invocations
    }
}
