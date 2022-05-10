using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextMesh : MonoBehaviour
{
    SeatStore seatManager;
    public TextMeshPro label;

    void Start()
    {
        seatManager = FindObjectOfType<SeatStore>();
        label = GetComponent<TextMeshPro>();
    }
}
