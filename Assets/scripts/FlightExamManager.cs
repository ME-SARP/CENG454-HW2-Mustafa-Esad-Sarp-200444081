using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    void Start()
    {
        
        statusText.text = ""; 
    }

    public void EnterDangerZone()
    {
        
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }
    }

    public void ExitDangerZone()
    {
        
        threatCleared = true;
        
        if (statusText != null)
        {
            statusText.text = "Safe Zone";
            statusText.color = Color.green;
        }
    }
}
