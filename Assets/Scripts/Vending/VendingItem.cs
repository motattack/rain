using UnityEngine;

[CreateAssetMenu(fileName = "VendingItem")]
public class VendingItem : ScriptableObject
{
    public PickUpObject item;
    public int price;
}
