using UnityEngine;

public class DoorControl :  MonoBehaviour, DeviceInterface
{
    [SerializeField]
    bool isOpen = false;

    public void Action()
    {
        if (isOpen)
        {
            Debug.Log("Closing the door."); //문 닫는 동작, 애니메이션 추가 등
            isOpen = false;
        }
        else
        {
            Debug.Log("Opening the door."); //문 여는 동작, 애니메이션 추가 등
            isOpen = true;
        }
    }
}
