using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public float gridCellSize = 1f;

    void OnDrawGizmos()
    {
        if (rows == 0 || columns == 0 || gridCellSize == 0f)
            return;
        
        Gizmos.color = Color.white;

        float width = columns * gridCellSize;
        float height = rows * gridCellSize;

        for (int i = 0; i <= rows; i++)
        {
            var startPos = transform.position + i * gridCellSize * Vector3.forward;
            var endPos = startPos + width * Vector3.right;
            Gizmos.DrawLine(startPos, endPos);
        }

        for (int i = 0; i <= columns; i++)
        {
            var startPos = transform.position + i * gridCellSize * Vector3.right;
            var endPos = startPos + height * Vector3.forward;
            Gizmos.DrawLine(startPos, endPos);
        }
    }
}
