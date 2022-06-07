using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tilemap colliderTile;
    [SerializeField] Tile wallTile;
    [SerializeField] Tile destroyableTile;
    [SerializeField] Tile floorTile;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
    }

    void ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        Collider2D destroyableCollider = colliderTile.GetComponent<Collider2D>();

        if (tile == wallTile)
        {
            return;
        }

        if (tile == destroyableTile)
        {
            tilemap.SetTile(cell, floorTile);
            Destroy(destroyableCollider);
            
        }

        //Crear explosion


    }
}
