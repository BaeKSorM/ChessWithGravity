using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Horse
{
    public bool isFirstMove;
    public override void MoveDirectionOn()
    {
        MoveDirectionOff();
        GameManager.Instance.horseTransform = transform;
        if (isFirstMove)
        {
            for (int i = 1; i <= 2; ++i)
            {
                int upTileOrder = currentTileOrder - GameManager.Instance.horiOrder * i;
                if (GameManager.Instance.upLastTile <= upTileOrder)
                {
                    GameManager.Instance.canMoveHorseToTlieOrders.Add(upTileOrder);
                }
            }
        }
        else
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(currentTileOrder - GameManager.Instance.horiOrder);
        }
        GameManager.Instance.ActivateCanSelcetDot();
    }
}
