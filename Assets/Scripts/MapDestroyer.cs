using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tilemap gameplayTiemap;
    [SerializeField] Tile wallTile;
    [SerializeField] Tile destroyableTile;
    [SerializeField] Tile floorTile;
    Vector3Int right = new Vector3Int(1, 0, 0); 
    Vector3Int up = new Vector3Int(0, 1, 0); 
    Vector3Int left = new Vector3Int(-1, 0, 0); 
    Vector3Int down = new Vector3Int(0, -1, 0); 
    
    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCells(originCell);
    }

    private void ExplodeCells(Vector3Int originCell)
    {
        ExplodeCell(originCell);
        ExplodeCell(originCell + right);
        ExplodeCell(originCell +left);
        ExplodeCell(originCell + up);
        ExplodeCell(originCell + down);
    }

    void ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell); 
        Tile gameplayTile = gameplayTiemap.GetTile<Tile>(cell); 
        if (tile == wallTile)
        {
            return;
        }

        if (gameplayTile == destroyableTile)
        {
            gameplayTiemap.SetTile(cell, null);            
        }
        
        //Crear explosion 


    }
}
