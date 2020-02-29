using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Color previewColor = new Color(1, 0, 0, 0.5f);
    public GameObject prefabtoSpawn;
    public bool ranfomizePrefabSpriteColor = true;

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

    private void SpawnItems()
    {

    }
}
