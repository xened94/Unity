using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }

    public bool HasLeftWall => _leftWall.activeSelf;
    public bool HasRightWall => _rightWall.activeSelf;
    public bool HasFrontWall => _frontWall.activeSelf;
    public bool HasBackWall => _backWall.activeSelf;

    public void SetLeftWall(bool active)
    {
        _leftWall.SetActive(active);
    }

    public void SetRightWall(bool active)
    {
        _rightWall.SetActive(active);
    }

    public void SetFrontWall(bool active)
    {
        _frontWall.SetActive(active);
    }

    public void SetBackWall(bool active)
    {
        _backWall.SetActive(active);
    }
}