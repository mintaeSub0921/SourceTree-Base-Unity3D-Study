using Unity.VisualScripting;
using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    private Vector3 targetPoint;
    public float steeringForce = 10f;

    public LayerMask ObstacleMask;

    private void Start()
    {
        targetPoint = Vector3.zero;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스를 클릭한 곳으로 레이저 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                targetPoint = hit.point; // 목적지 설정
            }
        }

        Vector3 dir = (targetPoint - transform.position).normalized; // 목적지 방향 벡터 계산

        dir = GetAvoidanceDirection(dir); // 장애물 회피 방향 계산

        if (Vector3.Distance(targetPoint, transform.position) < 1f) // Stop Distance
            return;

        transform.position += transform.forward * moveSpeed * Time.deltaTime; // 이동

        Quaternion rot = Quaternion.LookRotation(dir); // 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);

    }


    private Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;

        //정면을 향해 레이캐스트 발사 + 장애물 레이어 확인
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, ObstacleMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0; // 수평 방향으로만 회피

            dir = transform.forward + hitNormal * force;
            dir.Normalize();
        }

        return dir;
    }


}
