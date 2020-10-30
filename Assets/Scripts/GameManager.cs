using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static internal int Difficult { get; set; } = 1;
    static public int CurrentFloor { get; internal set; }
    static public int Score { get; internal set; } = 0;
    static public bool IsFloorBuilt {  get; internal set; } = false;

    [SerializeField] private GameObject _eventsManager;
    EventsManager _eventsManagerHandler;


    void Start()
    {
        Difficult = 1;
        CurrentFloor = 0;
        Score = 0;

        _eventsManagerHandler = _eventsManager.GetComponent<EventsManager>();
    }

    void Update()
    {
        if (IsFloorBuilt)
        {
            _eventsManagerHandler.FloorIsBuilt?.Invoke();
            IsFloorBuilt = false;
        }
    }
}
