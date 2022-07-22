using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public static Field instance = null;
    [SerializeField]
    public Dictionary<Vector2Int, Cell> field { get; private set; }
    [SerializeField] private Vector2Int fieldSize;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Vector2 cellSize = Vector2.one * 90;
    [SerializeField] private Vector2 spacing = Vector2.one * 10;
    [SerializeField] private Vector2 padding = Vector2.one * 5;

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    private void Start()
    {
        SpawnField();
        SpawnBalls();
    }

    private void SpawnBalls()
    {
        for (int i = 0; i < fieldSize.x; i++)
        {
            var ball = BallsContainer.instance.GetBall();
            var cellPos = new Vector2Int(i, 0);
            ball.position = cellPos;
            ball.UpdateWorldPosition();
            ball.Move();
        }
    }

    public bool IsCellExist(Vector2Int position)
    {
        return field.ContainsKey(position);
    }

    public Vector3 GetCellWorldPosition(Vector2Int position)
    {
        return field[position].transform.position;
    }

    private void SpawnField()
    {
        field = new Dictionary<Vector2Int, Cell>(fieldSize.x * fieldSize.y);
        Vector3 startPosition = new Vector3(padding.x + cellSize.x / 2, -1 * (padding.y + cellSize.y / 2), 0);
        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                var cell = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                var cellPosition = new Vector2Int(i, j);
                cell.position = cellPosition;
                field.Add(cellPosition, cell);
                cell.transform.localPosition = startPosition + new Vector3(i * spacing.x + i * cellSize.x, -1 * (j * spacing.y + j * cellSize.y), 0);
            }
            //spawner cells
            var spawnerCell = Instantiate(cellPrefab, transform).GetComponent<Cell>();
            var spawnerCellPosition = new Vector2Int(i, -1);
            spawnerCell.position = spawnerCellPosition;
            field.Add(new Vector2Int(i, -1), spawnerCell);
            spawnerCell.transform.localPosition = startPosition + new Vector3(i * spacing.x + i * cellSize.x, -1 * (-1 * spacing.y + -1 * cellSize.y), 0);
        }
    }
}
