using UnityEngine;

public class QuestMaster : MonoBehaviour
{
    [SerializeField] private DialogueObject completeMessage;
    [SerializeField] private Item objectToComplete;
    [SerializeField] private PickUpObject objectReward;
    private DialogueActivator _dialogueActivator;
    private bool _isCompleted = false;
    private bool _isStarted = false;

    private void Awake()
    {
        _dialogueActivator = GetComponent<DialogueActivator>();
    }

    public void StartQuest()
    {
        _isStarted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hero.instance.ToggleActionIndicator(true);
            if (_isStarted && !_isCompleted)
            {
                for (int i = 0; i < Inventory.instance._inventorySlots.Length; i++)
                {
                    if (objectToComplete == Inventory.instance._inventorySlots[i]._item)
                    {
                        _dialogueActivator.UpdateDialogueObject(completeMessage);
                        Inventory.instance.Delete(i);
                        GameObject itemPrefabInstance = Instantiate(objectReward.itemObj);
                        itemPrefabInstance.transform.position =
                            Hero.instance.transform.position + new Vector3(0f, 1f, 0f);
                        _isCompleted = true;
                        break;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hero.instance.ToggleActionIndicator(false);
        }
    }
}