
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using pruebaceldas;

namespace laberinto
{
public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    public MazeCell _mazeCellPrefab;

        [SerializeField]
        [Range(1, 100)] // Esto limita los valores posibles en el Inspector entre 1 y 100
        private int _mazeWidth = 20;

        [SerializeField]
        [Range(1, 100)] // Esto limita los valores posibles en el Inspector entre 1 y 100
        private int _mazeDepth = 20;

                [SerializeField]
        [Range(1, 100)] // Esto limita los valores posibles en el Inspector entre 1 y 100
        private int _numberOfManzanas = 20;

        public int MazeWidth => _mazeWidth;
        public int MazeDepth => _mazeDepth;
        public int numberOfManzanas => _numberOfManzanas;
    public MazeCell[,] _mazeGrid;

    public GameObject manzanasPrefab;
public MazeCell GetCellAt(int x, int z)
{
    if (x >= 0 && x < _mazeWidth && z >= 0 && z < _mazeDepth)
    {
        return _mazeGrid[x, z];
    }
    else
    {
        return null; // O puedes lanzar una excepción aquí según tus necesidades
    }
}
    void Start()
    {
    _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

    for (int x = 0; x < _mazeWidth; x++)
    {
        for (int z = 0; z < _mazeDepth; z++)
        {
            _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
        }
    }

        GenerateMaze(null, _mazeGrid[0, 0]);
        // Generar manzanas en posiciones aleatorias
             
    GenerateManzanas();
    }
    void GenerateManzanas()
{
    

    for (int i = 0; i < numberOfManzanas; i++)
    {
        // Genera una posición aleatoria dentro del laberinto
        int x = Random.Range(0, _mazeWidth);
        int z = Random.Range(0, _mazeDepth);

        // Ajusta la altura de la manzana según tu escenario
        float y = 1.0f;

        // Instancia la manzana en la posición aleatoria
        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(manzanasPrefab, spawnPosition, Quaternion.identity);
    }
}
         public void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
        {
            currentCell.Visit();
            ClearWalls(previousCell, currentCell);

            MazeCell nextCell;

            do
            {
                nextCell = GetNextUnvisitedCell(currentCell);

                if (nextCell != null)
                {
                    GenerateMaze(currentCell, nextCell);
                }
            } while (nextCell != null);
        }

        

    public MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    public IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, z];
            
            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

     public void ClearWalls(MazeCell previousCell, MazeCell currentCell)
        {
            if (previousCell == null)
            {
                return;
            }

            if (previousCell.transform.position.x < currentCell.transform.position.x)
            {
                previousCell.ClearRightWall();
                currentCell.ClearLeftWall();
                return;
            }

            if (previousCell.transform.position.x > currentCell.transform.position.x)
            {
                previousCell.ClearLeftWall();
                currentCell.ClearRightWall();
                return;
            }

            if (previousCell.transform.position.z < currentCell.transform.position.z)
            {
                previousCell.ClearFrontWall();
                currentCell.ClearBackWall();
                return;
            }

            if (previousCell.transform.position.z > currentCell.transform.position.z)
            {
                previousCell.ClearBackWall();
                currentCell.ClearFrontWall();
                return;
            }
        }

    

}
}