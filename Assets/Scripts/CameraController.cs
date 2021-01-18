using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Tilemap tileMap;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeft = tileMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0);
        topRight = tileMap.localBounds.max - new Vector3(halfWidth, halfHeight, 0);

        PlayerController.instance.setTileBounds(tileMap.localBounds.min, tileMap.localBounds.max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var positionX = target.position.x;
        var positionY = target.position.y;


        transform.position = new Vector3(positionX, positionY, transform.position.z);

        var position = transform.position;

        transform.position = new Vector3(Mathf.Clamp(position.x, bottomLeft.x, topRight.x),
            Mathf.Clamp(position.y, bottomLeft.y, topRight.y), position.z);
    }
}