using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (examManager != null)
        {
            examManager.CheckLanding(other.tag);
        }
    }
}