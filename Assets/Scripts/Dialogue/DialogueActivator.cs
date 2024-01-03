using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    
    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Hero hero))
        {
            hero.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Hero hero))
        {
            if (hero.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                hero.Interactable = null;
            }
        }
    }

    public void Interact(Hero hero)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                hero.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }
        
        hero.DialogueUI.ShowDialogue(dialogueObject);
    }
}
