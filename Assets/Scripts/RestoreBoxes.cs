using UnityEngine;

public class RestoreBoxes : MonoBehaviour
{
    private Transform[] boxes;

    private void Start()
    {
        
        GameObject[] boxObjects = GameObject.FindGameObjectsWithTag("Box");
        boxes = new Transform[boxObjects.Length];

        for (int i = 0; i < boxObjects.Length; i++)
        {
            boxes[i] = boxObjects[i].transform;
        }

        
        if (GameManager.Instance != null && GameManager.Instance.boxPositions != null &&
            GameManager.Instance.boxPositions.Length == boxes.Length)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] != null) 
                {
                    boxes[i].position = GameManager.Instance.boxPositions[i];
                }
            }
        }
        else
        {
            Debug.LogWarning("Box positions data is missing or does not match the number of boxes.");
        }
    }
}
