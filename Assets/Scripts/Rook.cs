using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Horse
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
            CheckRookCanMoveTiles();
            ActivateCanMoveTile();
            isMoveDirectionOn = true;
        }
    }
    public override void MoveDirectionOn()
    {
        MoveDirectionOff();
        GameManager.Instance.horseTransform = transform;
        for (int i = 1; i <= 15; ++i)
        {
            int leftTileOrder = currentTileOrder - i;
            if (GameManager.Instance.leftLastTile <= leftTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(leftTileOrder);
            }
            int rightTileOrder = currentTileOrder + i;
            if (GameManager.Instance.rightLastTile >= rightTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(rightTileOrder);
            }
            int upTileOrder = currentTileOrder - GameManager.Instance.horiOrder * i;
            if (GameManager.Instance.upLastTile <= upTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(upTileOrder);
            }
            int downTileOrder = currentTileOrder + GameManager.Instance.horiOrder * i;
            if (GameManager.Instance.downLastTile >= downTileOrder)
            {
                GameManager.Instance.canMoveHorseToTlieOrders.Add(downTileOrder);
            }
        }
        GameManager.Instance.ActivateCanSelcetDot();
    }
}
