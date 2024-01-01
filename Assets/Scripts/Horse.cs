using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

abstract public class Horse : MonoBehaviour
{
    public Button horseButton;
    public Vector2 horseSize;
    public bool isMoveDirectionOn;
    public int currentTileOrder;
    public RaycastHit2D[] leftTiles;
    public RaycastHit2D[] rightTiles;
    public RaycastHit2D[] upTiles;
    public RaycastHit2D[] downTiles;
    public RaycastHit2D[] leftUpTiles;
    public RaycastHit2D[] rightUpTiles;
    public RaycastHit2D[] leftDownTiles;
    public RaycastHit2D[] rightDownTiles;
    public RaycastHit2D betweenLeftAndLeftUp;
    public RaycastHit2D betweenLeftAndLeftDown;
    public RaycastHit2D betweenUpAndLeftUp;
    public RaycastHit2D betweenDownAndLeftDown;
    public RaycastHit2D betweenRightAndRightUp;
    public RaycastHit2D betweenRightAndRightDown;
    public RaycastHit2D betweenUpAndRightUp;
    public RaycastHit2D betweenDownAndRightDown;
    public Action ActivateCanMoveTile;
    public void Start()
    {
        horseButton = GetComponent<Button>();
        horseButton.onClick.AddListener(() => Pressed());
        horseSize = GetComponent<RectTransform>().sizeDelta / 2;
        ActivateCanMoveTile += CheckCurrentTileOrder;
        ActivateCanMoveTile += MoveDirectionOn;
    }
    public abstract void Pressed();
    public void CheckPawnCanMoveTiles()
    {
        upTiles = Physics2D.RaycastAll(transform.position + Vector3.up * GameManager.Instance.rayRange, Vector2.up, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        for (int i = 1; i < upTiles.Length; ++i)
        {
            if (upTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.upLastTile = int.Parse(upTiles[i - 1].transform.name);
                break;
            }
        }
    }
    public void CheckRookCanMoveTiles()
    {
        leftTiles = Physics2D.RaycastAll(transform.position + Vector3.left * GameManager.Instance.rayRange, Vector2.left, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightTiles = Physics2D.RaycastAll(transform.position + Vector3.right * GameManager.Instance.rayRange, Vector2.right, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        upTiles = Physics2D.RaycastAll(transform.position + Vector3.up * GameManager.Instance.rayRange, Vector2.up, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        downTiles = Physics2D.RaycastAll(transform.position + Vector3.down * GameManager.Instance.rayRange, Vector2.down, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        for (int i = 1; i < leftTiles.Length; ++i)
        {
            if (leftTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftLastTile = int.Parse(leftTiles[i - 1].transform.name);
                    break;
                }
            }
        }
        for (int i = 1; i < rightTiles.Length; ++i)
        {
            if (rightTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightLastTile = int.Parse(rightTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < upTiles.Length; ++i)
        {
            if (upTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.upLastTile = int.Parse(upTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < downTiles.Length; ++i)
        {
            if (downTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (downTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.downLastTile = int.Parse(downTiles[i - 1].transform.name);
                }
                break;
            }
        }
    }
    public void CheckBishopCanMoveTiles()
    {
        leftUpTiles = Physics2D.RaycastAll(transform.position + new Vector3(-1f, 1f) * GameManager.Instance.rayRange, new Vector2(-1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightUpTiles = Physics2D.RaycastAll(transform.position + new Vector3(1f, 1f) * GameManager.Instance.rayRange, new Vector2(1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        leftDownTiles = Physics2D.RaycastAll(transform.position + new Vector3(-1f, -1f) * GameManager.Instance.rayRange, new Vector2(-1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightDownTiles = Physics2D.RaycastAll(transform.position + new Vector3(1f, -1f) * GameManager.Instance.rayRange, new Vector2(1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        for (int i = 1; i < leftUpTiles.Length; ++i)
        {
            if (leftUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftUpTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftUpLastTile = int.Parse(leftUpTiles[i - 1].transform.name);
                    break;
                }
            }
        }
        for (int i = 1; i < rightUpTiles.Length; ++i)
        {
            if (rightUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightUpTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightUpLastTile = int.Parse(rightUpTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < leftDownTiles.Length; ++i)
        {
            if (leftDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftDownTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftDownLastTile = int.Parse(leftDownTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < rightDownTiles.Length; ++i)
        {
            if (rightDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightDownTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightDownLastTile = int.Parse(rightDownTiles[i - 1].transform.name);
                }
                break;
            }
        }
    }
    public void CheckKinghtCanMoveTiles()
    {
        betweenLeftAndLeftUp = Physics2D.Raycast(transform.position + new Vector3(-2f, 1f) * GameManager.Instance.rayRange, new Vector2(-2f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenLeftAndLeftDown = Physics2D.Raycast(transform.position + new Vector3(-2f, -1f) * GameManager.Instance.rayRange, new Vector2(-2f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenUpAndLeftUp = Physics2D.Raycast(transform.position + new Vector3(-1f, 2f) * GameManager.Instance.rayRange, new Vector2(-1f, 2f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenDownAndLeftDown = Physics2D.Raycast(transform.position + new Vector3(-1f, -2f) * GameManager.Instance.rayRange, new Vector2(-1f, -2f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenRightAndRightUp = Physics2D.Raycast(transform.position + new Vector3(2f, 1f) * GameManager.Instance.rayRange, new Vector2(2f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenRightAndRightDown = Physics2D.Raycast(transform.position + new Vector3(2f, -1f) * GameManager.Instance.rayRange, new Vector2(2f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer);
        betweenUpAndRightUp = Physics2D.Raycast(transform.position + new Vector3(1f, 2f) * GameManager.Instance.rayRange, new Vector2(1f, 2f), 216, GameManager.Instance.tileLayer);
        betweenDownAndRightDown = Physics2D.Raycast(transform.position + new Vector3(1f, -2f) * GameManager.Instance.rayRange, new Vector2(1f, -2f), Mathf.Infinity, GameManager.Instance.tileLayer);
        if (betweenLeftAndLeftUp && betweenLeftAndLeftUp.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenLeftAndLeftUpTile = int.Parse(betweenLeftAndLeftUp.transform.name);
        }
        if (betweenLeftAndLeftDown && betweenLeftAndLeftDown.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenLeftAndLeftDownTile = int.Parse(betweenLeftAndLeftDown.transform.name);
        }
        if (betweenUpAndLeftUp && betweenUpAndLeftUp.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenUpAndLeftUpTile = int.Parse(betweenUpAndLeftUp.transform.name);
        }
        if (betweenDownAndLeftDown && betweenDownAndLeftDown.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenDownAndLeftDownTile = int.Parse(betweenDownAndLeftDown.transform.name);
        }
        if (betweenRightAndRightUp && betweenRightAndRightUp.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenRightAndRightUpTile = int.Parse(betweenRightAndRightUp.transform.name);
        }
        if (betweenRightAndRightDown && betweenRightAndRightDown.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenRightAndRightDownTile = int.Parse(betweenRightAndRightDown.transform.name);
        }
        if (betweenUpAndRightUp && betweenUpAndRightUp.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenUpAndRightUpTile = int.Parse(betweenUpAndRightUp.transform.name);
        }
        if (betweenDownAndRightDown && betweenDownAndRightDown.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            GameManager.Instance.betweenDownAndRightDownTile = int.Parse(betweenDownAndRightDown.transform.name);
        }
    }
    public void CheckKingQueenCanMoveTiles()
    {
        leftTiles = Physics2D.RaycastAll(transform.position + Vector3.left * GameManager.Instance.rayRange, Vector2.left, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightTiles = Physics2D.RaycastAll(transform.position + Vector3.right * GameManager.Instance.rayRange, Vector2.right, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        upTiles = Physics2D.RaycastAll(transform.position + Vector3.up * GameManager.Instance.rayRange, Vector2.up, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        downTiles = Physics2D.RaycastAll(transform.position + Vector3.down * GameManager.Instance.rayRange, Vector2.down, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        leftUpTiles = Physics2D.RaycastAll(transform.position + new Vector3(-1f, 1f) * GameManager.Instance.rayRange, new Vector2(-1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightUpTiles = Physics2D.RaycastAll(transform.position + new Vector3(1f, 1f) * GameManager.Instance.rayRange, new Vector2(1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        leftDownTiles = Physics2D.RaycastAll(transform.position + new Vector3(-1f, -1f) * GameManager.Instance.rayRange, new Vector2(-1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightDownTiles = Physics2D.RaycastAll(transform.position + new Vector3(1f, -1f) * GameManager.Instance.rayRange, new Vector2(1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        for (int i = 1; i < leftTiles.Length; ++i)
        {
            if (leftTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftLastTile = int.Parse(leftTiles[i - 1].transform.name);
                    break;
                }
            }
        }
        for (int i = 1; i < rightTiles.Length; ++i)
        {
            if (rightTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightLastTile = int.Parse(rightTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < upTiles.Length; ++i)
        {
            if (upTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.upLastTile = int.Parse(upTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < downTiles.Length; ++i)
        {
            Debug.Log(downTiles[i].transform.name);
            if (downTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (downTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.downLastTile = int.Parse(downTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < leftUpTiles.Length; ++i)
        {
            if (leftUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftUpTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftUpLastTile = int.Parse(leftUpTiles[i - 1].transform.name);
                    break;
                }
            }
        }
        for (int i = 1; i < rightUpTiles.Length; ++i)
        {
            if (rightUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightUpTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightUpLastTile = int.Parse(rightUpTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < leftDownTiles.Length; ++i)
        {
            if (leftDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (leftDownTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.leftDownLastTile = int.Parse(leftDownTiles[i - 1].transform.name);
                }
                break;
            }
        }
        for (int i = 1; i < rightDownTiles.Length; ++i)
        {
            if (rightDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (rightDownTiles[i - 1].collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
                {
                    GameManager.Instance.rightDownLastTile = int.Parse(rightDownTiles[i - 1].transform.name);
                }
                break;
            }
        }
    }
    public void CheckCurrentTileOrder()
    {
        Collider2D currentTile = Physics2D.OverlapBox(transform.position, horseSize, 0, GameManager.Instance.tileLayer);
        if (currentTile)
        {
            currentTileOrder = int.Parse(currentTile.name);
        }
    }

    public abstract void MoveDirectionOn();
    public void MoveDirectionOff()
    {
        if (GameManager.Instance.horseTransform != null)
        {
            GameManager.Instance.horseTransform.GetComponent<Horse>().isMoveDirectionOn = false;
            GameManager.Instance.horseTransform = null;
        }
        for (int i = 0; i < GameManager.Instance.canMoveHorseToTlieOrders.Count; ++i)
        {
            GameManager.Instance.DeactivateCanSelcetDot(i);
        }
        GameManager.Instance.canMoveHorseToTlieOrders = new List<int>();
    }
}
