using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform[] boxes; // Assign all box objects in the inspector

    public void SaveAndLoadNextScene()
    {
        // Save box positions
        GameManager.Instance.boxPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            GameManager.Instance.boxPositions[i] = boxes[i].position;
        }

        SceneManager.LoadScene("NextScene"); // Load new scene
    }
}
//attach this script into whatever triggers the next scene