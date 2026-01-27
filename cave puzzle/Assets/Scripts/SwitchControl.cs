using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour, DeviceInterface
{
    public List<GameObject> linkedDevice = new List<GameObject>(); //연결된 장치들의 리스트
    public bool isActive = false;
    public void Action()
    {
        Debug.Log("Switch toggled.");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Action();
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }
}
