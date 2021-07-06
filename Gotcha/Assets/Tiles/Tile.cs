using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    Color meshMouseOverColor = new Color(0.8f,0.8f,0.8f,0.01f);
    Color meshOriginalColor;

    MeshRenderer mRenderer;

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        mRenderer = transform.Find("grass").GetComponent<MeshRenderer>();
        meshOriginalColor = mRenderer.material.color;

        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!IsPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            mRenderer.material.color = meshMouseOverColor;
            if (Input.GetMouseButtonDown(0) && gridManager.GetNode(coordinates).isPassable && !pathfinder.WillBlockPath(coordinates))
            {
                bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
                if (isSuccessful)
                {
                    gridManager.BlockNode(coordinates);
                    pathfinder.NotifyReceivers();
                }
                mRenderer.material.color = meshOriginalColor;
            }
        }
    }

    private void OnMouseExit()
    {
        if (mRenderer.material.color != meshOriginalColor)
        {
            mRenderer.material.color = meshOriginalColor;
        }
    }
}
