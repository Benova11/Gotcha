using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color exploredColor = Color.yellow;
    //[SerializeField] Color blockedColor = Color.green;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);//orange

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        gridManager = FindObjectOfType<GridManager>();
        label.enabled = false;
        DisplayCoordiantes();
        UpdateObjectNameByCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordiantes();
            UpdateObjectNameByCoordinates();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        Node node = gridManager.GetNode(coordinates);

        if (gridManager!= null && node != null)
        {

            if (!node.isPassable)
            {
                label.color = blockedColor;
            }
            else if(node.isPath)
            {
                label.color = pathColor;
            }
            else if (node.isExplored)
            {
                label.color = exploredColor;
            }
            else
            {
                label.color = defaultColor;
            }
        }
        else return;

    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    void DisplayCoordiantes()
    {
        if(gridManager == null) { return; };

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectNameByCoordinates()
    {
        transform.parent.name = coordinates.ToString();
    }
}
