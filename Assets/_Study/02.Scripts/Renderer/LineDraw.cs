using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer line;

    private int LineCount;

    public Color color;

    public float lineWidth = 0.05f;

    public List<GameObject> lineObjs = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineObj = new GameObject("Line");
            line = lineObj.AddComponent<LineRenderer>();
            line.useWorldSpace = false;

            line.startWidth = lineWidth;
            line.endWidth = lineWidth;

            line.startColor = color;
            line.endColor = color;

            line.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

            lineObjs.Add(lineObj);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            line.positionCount = ++LineCount;
            line.SetPosition(LineCount - 1, worldPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            LineCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var lineObj in lineObjs)
                Destroy(lineObj);

            lineObjs.Clear();
        }


    }



}
