using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private PaddleMovement forPlayer;
    
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        FindObjectOfType<PointManager>().OnScoreUpdate += HandleScoreUpdate;
    }

    private void HandleScoreUpdate(PaddleMovement paddle, int score)
    {
        if (paddle != forPlayer) return;

        text.text = score.ToString();
    }
}