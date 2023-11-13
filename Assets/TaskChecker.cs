using System;
using UnityEngine;

public class TaskChecker : MonoBehaviour
{
    [SerializeField] private GameObject targer;
    [SerializeField] private DialogueObject nextDialogue;
    private GameObject tasker;
    private int curentTask = 0;

    private void Start()
    {
        tasker = GameObject.FindWithTag("Cat");
        Debug.Log("correct");
    }

    private void FixedUpdate()
    {
        if (curentTask == 0)
        {
            if (targer.GetComponent<Bowl>().Step == Bowl.STEP_READY)
            {
                tasker.GetComponent<DialogueActivator>().UpdateDialogueObject(nextDialogue);
                curentTask++;
            }
        }
    }
}
