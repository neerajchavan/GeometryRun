using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileprefab;
    public Transform playerTransform;
    private float spwanZ = 0.0f;
    private float TileLength = 50.0f;
    private float SafeZone = 60.0f;
    private int TileAmount = 7;
    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 

        for(int i=0; i<TileAmount;i++)
        {
            if (i < 2)
                SpwanTile(0);
            else
                SpwanTile();
        }
    } 

    // Update is called once per frame
    void Update()
    {
     if(playerTransform.position.z - SafeZone> (spwanZ - TileAmount * TileLength))
        {
            SpwanTile();
            DeleteTile();
        }
    }

    void SpwanTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tileprefab[RandomIndex()]) as GameObject;
        else
            go = Instantiate(tileprefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spwanZ;
        spwanZ += TileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomIndex()
    {
        int randomIndex = Random.Range(0, tileprefab.Length);
        return randomIndex;
    }
}
