using UnityEngine;
using TMPro;

public class TextMissionHandler : MonoBehaviour
{
    [SerializeField] private TextMission textMission;
    [SerializeField] private TMP_Text missionName;

    [SerializeField] private TMP_Text missionNameShow;
    [SerializeField] private TMP_Text missionDescriptionShow;
    
    private void Awake()
    {
        missionName.text = textMission.missionName;
    }

    public void AddContent()
    {
        missionNameShow.text = textMission.missionName;
        missionDescriptionShow.text = textMission.missionContent;
    }
}
