using UnityEngine;

public class MouseParticle : MonoBehaviour
{
    private ParticleSystem ps;

    public int burstCount = 30;
    public float timer = 2f;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
        var mainModule = ps.main;
        mainModule.startLifetime = timer;
        mainModule.gravityModifier = 1f;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;

        if (Input.GetMouseButtonDown(0))
            ps.Emit(burstCount);

    }



}
