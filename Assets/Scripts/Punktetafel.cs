using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Punktetafel : MonoBehaviour
{
    [SerializeField] private PaddelBewegung fuerSpieler;
    
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        Schiedsrichter schiedsrichter = FindObjectOfType<Schiedsrichter>();
        if (schiedsrichter != null) schiedsrichter.OnScoreUpdate += HandleScoreUpdate;
    }

    private void HandleScoreUpdate(PaddelBewegung paddle, int score)
    {
        if (paddle != fuerSpieler) return;

        text.text = score.ToString();
    }
}