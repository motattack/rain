using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject target;

    private void OnMouseDown() 
    {
        target.SetActive(!target.activeSelf);
    }
}
