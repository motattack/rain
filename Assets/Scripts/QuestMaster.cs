using System;
using UnityEngine;

public class QuestMaster : MonoBehaviour
{
    [SerializeField] private DialogueObject completeMessage;
    [SerializeField] private Item objectToComplete;
    private DialogueActivator _dialogueActivator;
    private bool _isCompleted = false;

    private void Awake()
    {
        _dialogueActivator = GetComponent<DialogueActivator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isCompleted)
        {
            for (int i = 0; i < Inventory.instance.InventorySlots.Length; i++)
            {
                if (objectToComplete == Inventory.instance.InventorySlots[i]._item)
                {
                    _dialogueActivator.UpdateDialogueObject(completeMessage);
                    Inventory.instance.Delete(i);
                    _isCompleted = true;
                    break;
                }
            }
        }
    }
}
