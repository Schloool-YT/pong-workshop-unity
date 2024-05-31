using UnityEngine;
using UnityEngine.Serialization;

public class Tor : MonoBehaviour
{
    [SerializeField] private PaddelBewegung fuerSpieler;
    [SerializeField] private ParticleSystem punkteEffekt;

    private Schiedsrichter schiedsrichter;

    private void Start()
    {
        schiedsrichter = FindObjectOfType<Schiedsrichter>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<BallBewegung>() == null) return;
        punkteEffekt.transform.position = col.GetContact(0).point;
        punkteEffekt.Play();
        
        schiedsrichter.AddScore(fuerSpieler);
    }
}