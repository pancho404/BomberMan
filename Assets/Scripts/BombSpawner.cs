using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 worldPos = playerOne.transform.position;
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPos);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Vector3 worldPos = playerTwo.transform.position;
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPos);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}
