using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
             
            if (examManager != null)
            {
                examManager.EnterDangerZone();
            }

            
            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            
            if (examManager != null)
            {
                examManager.ExitDangerZone();
            }
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("Missile launched!"); 
    }
}