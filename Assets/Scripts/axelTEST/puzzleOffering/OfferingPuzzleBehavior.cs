using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferingPuzzleBehavior : MonoBehaviour
{
    [Range(1,8)] //NE PAS DEPASSER
    public int itemQuantity = 1;

    [SerializeField]
    private List<Color> colors = new List<Color>();

    [SerializeField]
    public bool puzzleSolved = false;

    private List<Color> pureColors = new List<Color>();
    private GameObject SpawnZone;
    private GameObject PlacementZone;

    [SerializeField]
    public List<GameObject> jewels = new List<GameObject>();

    private void Awake()
    {
        this.CreatePureColors();
        this.GenerateRandomPureColors();
        this.SpawnZone = this.transform.GetChild(0).gameObject;
        this.PlacementZone = this.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        this.GenerateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateRandomColors()
    {
        for (int i = 0; i < this.itemQuantity; i++)
        {
            Color randomColor;
            do
            {
                randomColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1);
            } while (colors.IndexOf(randomColor) != -1);

            this.colors.Add(randomColor);

        }
    }

    private void CreatePureColors()
    {
        this.pureColors.Add(Color.white);
        this.pureColors.Add(Color.black);
        this.pureColors.Add(Color.green);
        this.pureColors.Add(Color.green);
        this.pureColors.Add(Color.red);
        this.pureColors.Add(Color.blue);
        this.pureColors.Add(Color.cyan);
        this.pureColors.Add(Color.yellow);
        this.pureColors.Add(Color.magenta);
        this.pureColors.Add(Color.grey);
    }

    private void GenerateRandomPureColors()
    {
        for (int i = 0; i < this.itemQuantity; i++)
        {
            Color randomColor;
            do
            {
                randomColor = this.pureColors[Random.Range(0,this.pureColors.Count)];
            } while (colors.IndexOf(randomColor) != -1);

            this.colors.Add(randomColor);
        }
    }

    private void GenerateItems()
    {
        this.SpawnZone.GetComponent<SpawnZone>().SpawnItems(this.itemQuantity,this.colors);
        this.PlacementZone.GetComponent<SpawnZone>().SpawnItems(this.itemQuantity,this.colors);
    }

    public void checkPuzzle(bool useless)
    {
        foreach (GameObject jewel in this.jewels)
        {
            if (!jewel.GetComponent<CarryJewels>().isPlaced)
            {
                return;
            }
        }
        this.puzzleSolved = true;
    }
}
