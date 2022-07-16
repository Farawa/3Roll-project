using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Dictionary<Vector2, Cell> field;
    [SerializeField] private Vector2 fieldSize;
    [SerializeField] private Vector2 spacing;
    [SerializeField] private GameObject cellPrefab;

    private void Start()
    {
        SpawnField();
    }

    private void SpawnField()
    {

    }
}
