using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextMesh : MonoBehaviour
{
    // Start is called before the first frame update
    SeatStore seatManager;
    TextMeshPro label;

    void Start()
    {
        seatManager = FindObjectOfType<SeatStore>();
        label = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seatManager && label)
        {
            label.text = $"New seat index: {seatManager.debugCounterInt}";
        }
        else
        {
            label.text = "Unavailable";
        }
    }
}
