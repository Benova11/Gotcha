using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        }

        ColorCoordinates();
        ToggleLabels();
    }

    void ColorCoordinates()
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
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectNameByCoordinates()
    {
        transform.parent.name = coordinates.ToString();
    }
}
