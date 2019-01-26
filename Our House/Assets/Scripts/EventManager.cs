using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventLog log;

    private void Awake()
    {
        this.tag = "em";
    }

}
