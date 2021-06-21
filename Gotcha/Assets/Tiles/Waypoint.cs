using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    Color meshMouseOverColor = new Color(0.8f,0.8f,0.8f,0.01f);
    Color meshOriginalColor;

    MeshRenderer mRenderer;

    private void Start()
    {
        mRenderer = GetComponentInChildren<MeshRenderer>();
        meshOriginalColor = mRenderer.material.color;
    }

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            mRenderer.material.color = meshMouseOverColor;
            if (Input.GetMouseButtonDown(0))
            {              
                bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
                isPlaceable = !isPlaced ;
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
