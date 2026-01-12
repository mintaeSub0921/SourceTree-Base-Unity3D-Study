using UnityEngine;

public class FieldCamera : MonoBehaviour
{
    private Transform target;

    [SerializeField] private Vector3 offset, minBounds, maxBounds;
    [SerializeField] private float smoothSpeed = 5f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 destination = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime); // 선형 이동 -> 부드럽게 변경되는 기능

        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        smoothedPosition.z = Mathf.Clamp(smoothedPosition.z, minBounds.z, maxBounds.z);

        transform.position = smoothedPosition; // 클리어카메라의 포지션을 0, 0, 0 으로 초기화를 시키지 않아서 transform.position 대신 transform.localPosition 사용


    }



}
