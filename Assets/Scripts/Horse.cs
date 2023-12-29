using System.Collections;
using System.Collections.Generic;
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
    public void Start()
    {
        horseButton = GetComponent<Button>();
        horseButton.onClick.AddListener(() => Pressed());
        horseSize = GetComponent<RectTransform>().sizeDelta / 2;
    }
    public void Pressed()
    {
        if (isMoveDirectionOn)
        {
            isMoveDirectionOn = false;
            MoveDirectionOff();
        }
        else
        {
            CheckCurrentTileOrder();
            CheckCanMoveTiles();
            MoveDirectionOn();
            isMoveDirectionOn = true;
        }
    }
    // abstract로만들고 세로, 가로, 대각선 해서, override해서 horse에서 가져오기
    public void CheckCanMoveTiles()
    {
        leftTiles = Physics2D.RaycastAll(transform.position, Vector2.left, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightTiles = Physics2D.RaycastAll(transform.position, Vector2.right, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        upTiles = Physics2D.RaycastAll(transform.position, Vector2.up, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        downTiles = Physics2D.RaycastAll(transform.position, Vector2.down, Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        leftUpTiles = Physics2D.RaycastAll(transform.position, new Vector2(-1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightUpTiles = Physics2D.RaycastAll(transform.position, new Vector2(1f, 1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        leftDownTiles = Physics2D.RaycastAll(transform.position, new Vector2(-1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        rightDownTiles = Physics2D.RaycastAll(transform.position, new Vector2(1f, -1f), Mathf.Infinity, GameManager.Instance.tileLayer | GameManager.Instance.wallLayer);
        Debug.Log($"left {leftTiles.Length} : rifht {rightTiles.Length} : up {upTiles.Length} : down {downTiles.Length}");
        for (int i = 1; i < leftTiles.Length; ++i)
        {
            if (leftTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.leftLastTile = int.Parse(leftTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < rightTiles.Length; ++i)
        {
            if (rightTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.rightLastTile = int.Parse(rightTiles[i - 1].transform.name);
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
                GameManager.Instance.downLastTile = int.Parse(downTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < leftUpTiles.Length; ++i)
        {
            if (leftUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.leftUpLastTile = int.Parse(leftUpTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < rightUpTiles.Length; ++i)
        {
            if (rightUpTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.rightUpLastTile = int.Parse(rightUpTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < leftDownTiles.Length; ++i)
        {
            if (leftDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.leftDownLastTile = int.Parse(leftDownTiles[i - 1].transform.name);
                break;
            }
        }
        for (int i = 1; i < rightDownTiles.Length; ++i)
        {
            if (rightDownTiles[i].collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameManager.Instance.rightDownLastTile = int.Parse(rightDownTiles[i - 1].transform.name);
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
