using UnityEngine;

public class CameraFollow_2D : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
