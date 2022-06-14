using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Animator animator;

    [SerializeField] Tilemap gameTilemap;
    [SerializeField] Tile wallTile;
    [SerializeField] Tile destroyableTile;
    [SerializeField] Tile floorTile;

    [SerializeField] float y;
    [SerializeField] float x;

    Vector3Int upLocation;
    Vector3Int downLocation;
    Vector3Int leftLocaction;
    Vector3Int rightLocation;
    Vector3Int location;

    bool runnable=true;
    void Start()
    {

    }

    void Update()
    {
        upLocation = gameTilemap.WorldToCell(transform.position + new Vector3(0f, 1f, 0f));
        downLocation = gameTilemap.WorldToCell(transform.position + new Vector3(0f, -1f, 0f));
        leftLocaction = gameTilemap.WorldToCell(transform.position + new Vector3(-1f, 0f, 0f));
        rightLocation = gameTilemap.WorldToCell(transform.position + new Vector3(1f, 0f, 0f));

        if (Input.GetKeyDown(KeyCode.W))
        {
            location = upLocation;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            location = downLocation;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            location = rightLocation;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            location = leftLocaction;
        }

        Tile tile = gameTilemap.GetTile<Tile>(location);

        if (gameTilemap == wallTile)
        {
            runnable = false;
        }
        if (gameTilemap == destroyableTile)
        {
            runnable = false;
        }
        if (gameTilemap == floorTile)
        {
            runnable = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && runnable)
        {
            transform.position += new Vector3(0f, y, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S) && runnable)
        {
            transform.position += new Vector3(0f, -y, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D) && runnable)
        {
            transform.position += new Vector3(x, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.A) && runnable)
        {
            transform.position += new Vector3(-x, 0f, 0f);
        }

    }
}

