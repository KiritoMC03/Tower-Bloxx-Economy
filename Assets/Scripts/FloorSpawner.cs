using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _hook;
    [SerializeField] private Transform _spawnPos;
    private Rigidbody2D _hookRigidbody;

    [SerializeField] private float _forceToX = 0;
    [SerializeField] private float _forceToY = 0;
    [SerializeField] private float _angularVelocityToFloor = 2f;
    internal bool CanSpawn { get; set; } = true;

    private Vector3 _spawnPosition;

    void Start()
    {
        CanSpawn = true;

        _hookRigidbody = _hook.GetComponent<Rigidbody2D>();
        _spawnPosition = new Vector3(0, -0.55f, 0);
    }

    void Update()
    {
        if (CanSpawn)
        {
            SpawnFloor();
        }
    }

    private void SpawnFloor()
    {
        Debug.Log("A");
        var _newFloor = Instantiate(_floor, _spawnPos);
        _newFloor.GetComponent<Rigidbody2D>().isKinematic = true;
        _newFloor.transform.localPosition = _spawnPosition;

        CanSpawn = false;
    }
}
