using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    [SerializeField] int numberOfLive;
    [SerializeField] GameObject heartObject;
    private List<GameObject> heartArray;
    private readonly float offset = 1f;
    public event EventHandler OnLose;
    private void Awake()
    {
        Instance = this;
        heartArray = new List<GameObject>();
    }
    private void Start()
    {
        Vector3 startPosition = heartObject.transform.position; 
        for(int i =0; i < numberOfLive; i++)
        {
            GameObject cloneHeartObject;
            if(i == 0)
            {
                cloneHeartObject = heartObject;
            }
            else
            {
                cloneHeartObject = Instantiate(heartObject) as GameObject;
            }
            heartArray.Add(cloneHeartObject);
            float posX = (offset * i) + startPosition.x;
            cloneHeartObject.transform.position = new Vector3(posX, startPosition.y, startPosition.z);
        }
        //Debug.Log(heartArray.Count);
        CardManager.Instance.OnRemoveLife += SceneController_OnRemoveLife;
    }
    
    private void SceneController_OnRemoveLife(object sender, System.EventArgs e)
    {
        if(heartArray.Count > 0)
        {
            GameObject heartRemoved = heartArray[heartArray.Count - 1];
            heartArray.Remove(heartRemoved);
            Destroy(heartRemoved);
            if(heartArray.Count == 0)
            {
                OnLose?.Invoke(this, EventArgs.Empty);
            }
            // Debug.Log(heartArray.Count);

        }
    }
    public bool isAlive()
    {
        return heartArray.Count > 0;
    }
}
