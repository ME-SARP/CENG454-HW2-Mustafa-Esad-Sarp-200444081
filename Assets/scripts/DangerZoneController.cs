using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
    
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered! Target: " + collision.gameObject.name);

            if (examManager != null)
            {
                examManager.EnterDangerZone();
            }

            
            activeCountdown = StartCoroutine(MissileCountdown(collision.transform));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the zone.");

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            if (examManager != null)
            {
                examManager.ExitDangerZone();
            }

            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator MissileCountdown(Transform playerTransform)
    {
        Debug.Log("Countdown started... Waiting " + missileDelay + " seconds.");
        yield return new WaitForSeconds(missileDelay);
        
        if (missileLauncher != null)
        {
            Debug.Log("Launching Missile now!");
            missileLauncher.Launch(playerTransform);
        }
        else
        {
            Debug.LogError("MissileLauncher is NOT assigned in the Inspector!");
        }
    }
}