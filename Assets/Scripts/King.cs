using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Horse
{
    public override void Pressed()
    {
        if (isMoveDirectionOn)
        {
            isMoveDirectionOn = false;
            MoveDirectionOff();
        }
        else
        {
            CheckKingQueenCanMoveTiles();
            ActivateCanMoveTile();
            isMoveDirectionOn = true;
        }
    }
    public override void MoveDirectionOn()
    {
        MoveDirectionOff();
        GameManager.Instance.horseTransform = transform;
        int leftUpTileOrder = currentTileOrder - (1 + 1 * GameManager.Instance.horiOrder);
        if (GameManager.Instance.leftUpLastTile <= leftUpTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(leftUpTileOrder);
        }
        int rightUpTileOrder = currentTileOrder + (1 - 1 * GameManager.Instance.horiOrder);
        if (GameManager.Instance.rightUpLastTile <= rightUpTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(rightUpTileOrder);
        }
        int leftDownTileOrder = currentTileOrder - (1 - 1 * GameManager.Instance.horiOrder);
        if (GameManager.Instance.leftDownLastTile >= leftDownTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(leftDownTileOrder);
        }
        int rightDownTileOrder = currentTileOrder + (1 + 1 * GameManager.Instance.horiOrder);
        if (GameManager.Instance.rightDownLastTile >= rightDownTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(rightDownTileOrder);
        }
        int leftTileOrder = currentTileOrder - 1;
        if (GameManager.Instance.leftLastTile <= leftTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(leftTileOrder);
        }
        int rightTileOrder = currentTileOrder + 1;
        if (GameManager.Instance.rightLastTile >= rightTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(rightTileOrder);
        }
        int upTileOrder = currentTileOrder - GameManager.Instance.horiOrder * 1;
        if (GameManager.Instance.upLastTile <= upTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(upTileOrder);
        }
        int downTileOrder = currentTileOrder + GameManager.Instance.horiOrder * 1;
        if (GameManager.Instance.downLastTile >= downTileOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(downTileOrder);
        }
        GameManager.Instance.ActivateCanSelcetDot();
    }
}