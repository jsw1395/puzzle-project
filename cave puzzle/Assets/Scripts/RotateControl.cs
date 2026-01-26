using System.Collections;
using UnityEngine;

public class RotateControl : MonoBehaviour, DeviceInterface
{
    public enum RotateDir { Clockwise, CounterClockwise }

    [SerializeField] float rotateAngle = 45.0f;   // 한 번에 도는 각도
    [SerializeField] float rotateTime = 1.0f;
    [SerializeField] RotateDir direction = RotateDir.Clockwise;

    bool isRotating = false;

    public void Action()
    {
        if (isRotating) return;

        float signedAngle = (direction == RotateDir.Clockwise)
            ? -rotateAngle   // Unity 2D: Z축 음수 = 시계
            : rotateAngle;  // Z축 양수 = 반시계

        StartCoroutine(RotateByAngle(signedAngle, rotateTime));
    }

    IEnumerator RotateByAngle(float deltaAngle, float duration)
    {
        isRotating = true;

        float startZ = transform.eulerAngles.z;
        float targetZ = startZ + deltaAngle;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float lerp = Mathf.Clamp01(t / duration);

            float z = Mathf.LerpAngle(startZ, targetZ, lerp);
            transform.rotation = Quaternion.Euler(0f, 0f, z);

            yield return null;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, targetZ);
        isRotating = false;
    }
}
