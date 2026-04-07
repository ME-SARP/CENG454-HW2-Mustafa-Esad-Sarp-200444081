using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    
    private GameObject activeMissile;

    
    public GameObject Launch(Transform target)
    {
        
        if (missilePrefab != null && launchPoint != null)
        {
            activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
            
            
            activeMissile.SendMessage("SetTarget", target, SendMessageOptions.DontRequireReceiver);
            
            return activeMissile;
        }
        
        return null;
    }

    
    public void DestroyActiveMissile()
    {
        
        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }
    }
}