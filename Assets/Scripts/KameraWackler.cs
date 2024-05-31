using UnityEngine;

public class KameraWackler : MonoBehaviour
{
    private Animator animator;
    private static readonly int Shake = Animator.StringToHash("Shake");

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        Schiedsrichter schiedsrichter = FindObjectOfType<Schiedsrichter>();
        if (schiedsrichter != null) schiedsrichter.OnScoreUpdate += HandleScoreUpdate;
    }

    private void HandleScoreUpdate(PaddelBewegung paddelBewegung, int score)
    {
        animator.SetTrigger(Shake);
    }
}