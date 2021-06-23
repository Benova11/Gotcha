using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.green;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordiantes();
        waypoint = GetComponentInParent<Waypoint>();
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
        if (!waypoint.IsPlaceable)
        {
            label.color = blockedColor;
        }else
        {
            label.color = defaultColor;
        }
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
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectNameByCoordinates()
    {
        transform.parent.name = coordinates.ToString();
    }
}
