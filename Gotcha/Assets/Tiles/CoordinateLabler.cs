using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordiantes();
        UpdateObjectNameByCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordiantes();
            UpdateObjectNameByCoordinates();
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
