using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour, DeviceInterface
{
    public List<GameObject> linkedDevice = new List<GameObject>(); //레버에 연결된 장치들의 리스트
    public bool isActive = false;
    public void Action()
    {
        Debug.Log("Lever pulled.");
        transform.localScale = transform.localScale * new Vector2(-1, 1); //레버의 방향을 반전
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
        foreach (GameObject device in linkedDevice)
        {
            DeviceInterface deviceInterface = device.GetComponent<DeviceInterface>(); 
            if (deviceInterface != null) //연결된 GameObject의 스크립트가 DeviceInterface를 가지는지 확인하고 Action() 호출
            {
                deviceInterface.Action();
            }
            else
            {
                Debug.LogWarning("Linked device does not implement DeviceInterface.");
            }
        }
    }
}
