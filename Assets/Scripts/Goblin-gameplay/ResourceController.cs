using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceController : MonoBehaviour
{
    public int calizInventory;
    public List<ActivableResourceEvents> activableResourceEvents = new List<ActivableResourceEvents>();

    #region Singleton
    public static ResourceController instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    #endregion
    public void addCaliz()
    {
        calizInventory++;
        for (int i = 0; i < activableResourceEvents.Count; i++)
        {
            if(calizInventory == activableResourceEvents[i].amount)
            {
                activableResourceEvents[i].resourceEvent.Invoke();
            }
        }
    }
}
[System.Serializable]
public class ActivableResourceEvents
{
    public int amount;
    public UnityEvent resourceEvent;
    
}