using UnityEngine;
using UnityEngine.Serialization;

public class PaddelBewegung : MonoBehaviour
{
    [SerializeField] private KeyCode hochTaste;
    [SerializeField] private KeyCode runterTaste;
    [SerializeField] private float geschwindigkeit = 5f;
    [SerializeField] private float hoehenVersatz = 0.2f;

    private float minY, maxY;
    private float height;

    private void Start()
    {
        Camera camera = Camera.main;
        minY = camera.ViewportToWorldPoint(Vector3.zero).y;
        maxY = camera.ViewportToWorldPoint(Vector3.one).y;
        height = GetComponent<BoxCollider2D>().bounds.size.y / 2f + hoehenVersatz;
    }

    private void Update()
    {
        if (Input.GetKey(hochTaste)) transform.Translate(Vector3.up * geschwindigkeit * Time.deltaTime);
        if (Input.GetKey(runterTaste)) transform.Translate(Vector3.down * geschwindigkeit * Time.deltaTime);

        float currentY = transform.position.y;
        if (currentY + height > maxY) transform.position = new Vector3(transform.position.x, maxY - height);
        if (currentY - height < minY) transform.position = new Vector3(transform.position.x, minY + height);
    }
}