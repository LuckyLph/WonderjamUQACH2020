using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Color previewColor = new Color(1, 0, 0, 0.5f);
    public GameObject prefabtoSpawn;
    public bool ranfomizePrefabSpriteColor = true;

    public Sprite spriteToUse;

    [SerializeField]
    private List<Vector2> positions = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = this.previewColor;
        Gizmos.DrawCube(this.transform.position, new Vector3(this.transform.localScale.x,this.transform.localScale.y));
    }

    private void GenerateRandomPositionsWithinGizmos(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            this.positions.Add(new Vector3(this.transform.position.x + Random.Range(-this.transform.localScale.x / 2, this.transform.localScale.x /2),
                                            this.transform.position.y + Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2)));
        }
    }

    public void SpawnItems(int quantity, List<Color> colors)
    {
        this.GenerateRandomPositionsWithinGizmos(quantity);
        for (int i = 0; i < quantity; i++)
        {
            GameObject spawned = Instantiate(this.prefabtoSpawn, this.positions[i], Quaternion.identity);
            spawned.GetComponent<SpriteRenderer>().color = colors[i];
            if (this.spriteToUse)
            {
                spawned.GetComponent<SpriteRenderer>().sprite = this.spriteToUse;
            }
            if (spawned.tag == "Jewel")
            {
                spawned.GetComponent<CarryJewels>().myColor = colors[i];
                this.GetComponentInParent<OfferingPuzzleBehavior>().jewels.Add(spawned);
                spawned.GetComponent<CarryJewels>().OnVariableChange += this.GetComponentInParent<OfferingPuzzleBehavior>().checkPuzzle;
            }
        }
    }
}
