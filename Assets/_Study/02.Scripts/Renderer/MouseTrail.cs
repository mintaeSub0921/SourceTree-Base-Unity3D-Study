using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    private TrailRenderer trail;

    public float timer = 0.25f;

    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        trail.time = timer;

        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }



}
