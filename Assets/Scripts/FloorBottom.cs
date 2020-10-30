using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBottom : MonoBehaviour
{
    private int ID;
    private bool _adjoined = false;

    [SerializeField]

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Foundation" || (collision.gameObject.GetComponent<Floor>() != null && collision.transform.tag == "Floor"))
        {
            Destroy(gameObject.GetComponent<FloorBottom>().gameObject);
            GameObject.FindGameObjectWithTag("FloorSpawner").GetComponent<FloorSpawner>().CanSpawn = true;
            GameManager.Score += 1;
            GameManager.CurrentFloor += 1;
            GameManager.IsFloorBuilt = true;
        }
    }
}
