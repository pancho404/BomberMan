using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 worldPos = player.transform.position;
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPos);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}
