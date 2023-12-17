using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    public LapCounter lapCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lapCounter.PlayerCrossedFinishLine();
        }
    }
}
