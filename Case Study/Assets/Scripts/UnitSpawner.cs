using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public ControlledUnit unitPrefabs;

    public GameObject parentObject;

    public void spawnUnit()
    {
        ControlledUnit unit = Instantiate(unitPrefabs,transform.position,Quaternion.identity);

        unit.transform.SetParent(parentObject.transform);

        Vector3 newPosition = unit.transform.position;

        newPosition.y = 1.0f;

        unit.transform.position = newPosition;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        spawnUnit();
    }
}
