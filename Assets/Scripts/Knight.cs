using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Horse
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
            CheckKinghtCanMoveTiles();
            ActivateCanMoveTile();
            isMoveDirectionOn = true;
        }
    }
    public override void MoveDirectionOn()
    {
        MoveDirectionOff();
        GameManager.Instance.horseTransform = transform;
        int betweenLeftAndLeftDownOrder = currentTileOrder - 2 + GameManager.Instance.horiOrder;
        if (GameManager.Instance.betweenLeftAndLeftDownTile == betweenLeftAndLeftDownOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenLeftAndLeftDownOrder);
        }
        int betweenLeftAndLeftUpOrder = currentTileOrder - 2 - GameManager.Instance.horiOrder;
        if (GameManager.Instance.betweenLeftAndLeftUpTile == betweenLeftAndLeftUpOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenLeftAndLeftUpOrder);
        }
        int betweenUpAndLeftUpOrder = currentTileOrder - 1 - GameManager.Instance.horiOrder * 2;
        if (GameManager.Instance.betweenUpAndLeftUpTile == betweenUpAndLeftUpOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenUpAndLeftUpOrder);
        }
        int betweenDownAndLeftDownOrder = currentTileOrder - 1 + GameManager.Instance.horiOrder * 2;
        if (GameManager.Instance.betweenDownAndLeftDownTile == betweenDownAndLeftDownOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenDownAndLeftDownOrder);
        }
        int betweenRightAndRightDownOrder = currentTileOrder + 2 + GameManager.Instance.horiOrder;
        if (GameManager.Instance.betweenRightAndRightDownTile == betweenRightAndRightDownOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenRightAndRightDownOrder);
        }
        int betweenRightAndRightUpOrder = currentTileOrder + 2 - GameManager.Instance.horiOrder;
        if (GameManager.Instance.betweenRightAndRightUpTile == betweenRightAndRightUpOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenRightAndRightUpOrder);
        }
        int betweenUpAndRightUpOrder = currentTileOrder + 1 - GameManager.Instance.horiOrder * 2;
        if (GameManager.Instance.betweenUpAndRightUpTile == betweenUpAndRightUpOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenUpAndRightUpOrder);
        }
        int betweenDownAndRightDownOrder = currentTileOrder + 1 + GameManager.Instance.horiOrder * 2;
        if (GameManager.Instance.betweenDownAndRightDownTile == betweenDownAndRightDownOrder)
        {
            GameManager.Instance.canMoveHorseToTlieOrders.Add(betweenDownAndRightDownOrder);
        }
        Debug.Log($"{GameManager.Instance.betweenUpAndLeftUpTile}, {betweenUpAndLeftUpOrder}");
        GameManager.Instance.ActivateCanSelcetDot();
    }
}