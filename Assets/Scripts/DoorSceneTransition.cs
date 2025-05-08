using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorSceneTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level 2"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if Player collides with door
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
