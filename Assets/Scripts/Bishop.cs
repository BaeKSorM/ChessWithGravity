using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Horse
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
            CheckBishopCanMoveTiles();
            ActivateCanMoveTile();
            isMoveDirectionOn = true;
        }
    }
    public override void MoveDirectionOn()
    {
        MoveDirectionOff();
        GameManager.Instance.horseTransform = transform;
        for (int i = 1; i <= 9; ++i)
        {
            int leftUpTileOrder = currentTileOrder - (i + i * GameManager.Instance.horiOrder);
            if (GameManager.Instance.leftUpLastTile <= leftUpTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(leftUpTileOrder);
            }
            int rightUpTileOrder = currentTileOrder + (i - i * GameManager.Instance.horiOrder);
            if (GameManager.Instance.rightUpLastTile <= rightUpTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(rightUpTileOrder);
            }
            int leftDownTileOrder = currentTileOrder - (i - i * GameManager.Instance.horiOrder);
            if (GameManager.Instance.leftDownLastTile >= leftDownTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(leftDownTileOrder);
            }
            int rightDownTileOrder = currentTileOrder + (i + i * GameManager.Instance.horiOrder);
            if (GameManager.Instance.rightDownLastTile >= rightDownTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(rightDownTileOrder);
            }
        }
        GameManager.Instance.ActivateCanSelcetDot();
    }
}
