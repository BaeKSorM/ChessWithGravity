using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Button> tileButtons;
    public List<Image> tileImages;
    public List<int> canMoveHorseToTlieOrders;
    public Transform tiles;
    public LayerMask tileLayer;
    public LayerMask wallLayer;
    public Transform horseTransform;
    public int horiOrder;
    public int vertiOrder;
    public int leftLastTile;
    public int rightLastTile;
    public int upLastTile;
    public int downLastTile;
    public int leftUpLastTile;
    public int rightUpLastTile;
    public int leftDownLastTile;
    public int rightDownLastTile;
    public int betweenLeftAndLeftUpTile;
    public int betweenLeftAndLeftDownTile;
    public int betweenUpAndLeftUpTile;
    public int betweenDownAndLeftDownTile;
    public int betweenRightAndRightUpTile;
    public int betweenRightAndRightDownTile;
    public int betweenUpAndRightUpTile;
    public int betweenDownAndRightDownTile;
    public float downSpeed;
    public float abs;
    public int rayRange;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        tiles = transform.Find("Tiles");
        for (int i = 0; i < tiles.childCount; ++i)
        {
            int count = i;
            tileImages.Add(tiles.GetChild(i).GetChild(0).GetComponent<Image>());
            tileButtons.Add(tiles.GetChild(i).GetComponent<Button>());
            tileButtons[i].onClick.AddListener(() => MoveHorse(tileButtons[count].name));
        }
    }
    void Update()
    {
        // Debug.Log(canMoveHorseToTlieOrders.Count);
    }
    void MoveHorse(string buttonName)
    {
        int tileOrder = int.Parse(buttonName);
        foreach (int order in canMoveHorseToTlieOrders)
        {
            if (tileOrder == order)
            {
                Debug.Log(canMoveHorseToTlieOrders.Count);
                for (int i = 0; i < canMoveHorseToTlieOrders.Count; ++i)
                {
                    DeactivateCanSelcetDot(i);
                }
                canMoveHorseToTlieOrders = new List<int>();
                horseTransform.GetComponent<Horse>().isMoveDirectionOn = false;
                if (horseTransform.GetComponent<Pawn>())
                {
                    horseTransform.GetComponent<Pawn>().isFirstMove = false;
                }
                horseTransform.position = tileButtons[tileOrder].transform.position;
                horseTransform.GetComponent<Rigidbody2D>().velocity = Vector2.down * downSpeed;
                break;
            }
        }
    }
    public void ActivateCanSelcetDot()
    {
        for (int i = 0; i < canMoveHorseToTlieOrders.Count; ++i)
        {
            if (canMoveHorseToTlieOrders[i] < tileImages.Count &&
                canMoveHorseToTlieOrders[i] >= 0)
            {
                tileImages[canMoveHorseToTlieOrders[i]].gameObject.SetActive(true);
            }
        }
    }
    public void DeactivateCanSelcetDot(int activeOrder)
    {
        if (canMoveHorseToTlieOrders[activeOrder] < tileImages.Count &&
            canMoveHorseToTlieOrders[activeOrder] >= 0)
        {
            tileImages[canMoveHorseToTlieOrders[activeOrder]].gameObject.SetActive(false);
        }
    }
    public void DisableSelectedDots()
    {
        for (int i = 0; i < canMoveHorseToTlieOrders.Count; ++i)
        {
            DeactivateCanSelcetDot(canMoveHorseToTlieOrders[i]);
            Debug.Log($"{canMoveHorseToTlieOrders[i]}, {i}");
        }
        if (horseTransform != null)
        {
            horseTransform.GetComponent<Horse>().isMoveDirectionOn = false;
        }
    }
}
