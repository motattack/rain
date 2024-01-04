using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextMission")]
public class TextMission : ScriptableObject
{
    public string missionName;
    [TextArea] public string missionContent;
}
