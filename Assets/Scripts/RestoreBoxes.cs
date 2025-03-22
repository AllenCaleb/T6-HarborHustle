using UnityEngine;

public class RestoreBoxes : MonoBehaviour
{
    public Transform[] boxes; // Assign all box objects in the inspector

    private void Start()
    {
        if (GameManager.Instance.boxPositions.Length > 0)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].position = GameManager.Instance.boxPositions[i];
            }
        }
    }
}
