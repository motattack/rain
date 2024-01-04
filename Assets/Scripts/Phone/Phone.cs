using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuApp;
    public static Phone instance;
    private Stack<GameObject> appStack;

    private void Start()
    {
        instance = this;
        appStack = new Stack<GameObject>();
        
        appStack.Push(mainMenuApp);
        ActivateTopApp();
    }
    
    public void AddApp(GameObject app)
    {
        DeactivateAllApps();
        appStack.Push(app);
        ActivateTopApp();
    }

    public void PopLastApp()
    {
        if (appStack.Count > 1)
        {
            DeactivateTopApp();
            appStack.Pop();
            
            if (appStack.Count > 0)
            {
                ActivateTopApp();
            }
        }
    }

    private void ActivateTopApp()
    {
        if (appStack.Count > 0)
        {
            GameObject topApp = appStack.Peek();
            topApp.SetActive(true);
        }
    }

    private void DeactivateTopApp()
    {
        if (appStack.Count > 0)
        {
            GameObject topApp = appStack.Peek();
            topApp.SetActive(false);
        }
    }
    
    private void DeactivateAllApps()
    {
        foreach (GameObject app in appStack)
        {
            app.SetActive(false);
        }
    }
}
