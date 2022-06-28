using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private KeyCode moveUpKey;
    [SerializeField] private KeyCode moveDownKey;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float heightOffset = 0.2f;

    private float minY, maxY;
    private float height;

    private void Start()
    {
        Camera camera = Camera.main;
        minY = camera.ViewportToWorldPoint(Vector3.zero).y;
        maxY = camera.ViewportToWorldPoint(Vector3.one).y;
        height = GetComponent<BoxCollider2D>().bounds.size.y / 2f + heightOffset;
    }

    private void Update()
    {
        if (Input.GetKey(moveUpKey)) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(moveDownKey)) transform.Translate(Vector3.down * speed * Time.deltaTime);

        float currentY = transform.position.y;
        if (currentY + height > maxY) transform.position = new Vector3(transform.position.x, maxY - height);
        if (currentY - height < minY) transform.position = new Vector3(transform.position.x, minY + height);
    }
}