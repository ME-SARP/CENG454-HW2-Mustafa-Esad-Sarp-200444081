using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasEnteredZone = false; 
    private bool threatCleared = false;  
    private bool missionComplete = false;

    void Start()
    {
        if (missionText != null) missionText.text = "Mission: Take off and head to the corridor.";
        if (statusText != null) statusText.text = "Status: Clear Airspace";
    }

    public void EnterDangerZone()
    {
        hasEnteredZone = true;
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }
    }

    public void ExitDangerZone()
    {
        if (hasEnteredZone)
        {
            threatCleared = true;
            if (statusText != null)
            {
                statusText.text = "Threat Cleared! Safe to Land.";
                statusText.color = Color.green;
            }
        }
    }

    
    public void CheckLanding(string areaTag)
    {
        if (missionComplete) return; // Görev zaten bittiyse bir şey yapma

        if (areaTag == "LandingArea")
        {
            
            if (hasEnteredZone && threatCleared)
            {
                CompleteMission();
            }
            else
            {
                if (statusText != null) 
                {
                    statusText.text = "Mission Failed: You must clear the threat first!";
                    statusText.color = Color.yellow;
                }
                Debug.Log("Önce tehlike bölgesine girmelisin!");
            }
        }
    }

    public void CompleteMission()
    {
        missionComplete = true;
        if (missionText != null) missionText.text = "MISSION COMPLETE: Safe Landing!";
        if (statusText != null) statusText.text = "All Goals Achieved.";
        
        Debug.Log("Mission Accomplished!");
        
    }
}