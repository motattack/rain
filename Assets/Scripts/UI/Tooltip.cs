using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipManager.Instance.SetAndShowTooltip(message);
    }

    private void OnMouseExit()
    {
        TooltipManager.Instance.HideTooltip();
    }
}
