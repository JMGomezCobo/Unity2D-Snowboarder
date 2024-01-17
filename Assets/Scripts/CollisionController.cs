using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Invoke(nameof(ReloadScene), 1f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}