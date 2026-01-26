using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour, DeviceInterface
{
    public List<GameObject> linkedDevice = new List<GameObject>(); //연결된 장치들의 리스트
    [SerializeField]
    int num = 0;

    public void Action()
    {
        Debug.Log("Plate toggled.");
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
        if(collision.tag == "Player" ||  collision.tag == "Stone")
        {
            if (num == 0) Action();
            num++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Stone")
        {
            num--;
            if (num == 0) Action();
        }
    }
}
