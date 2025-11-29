using UnityEngine;

public class SwitchControl : MonoBehaviour, DeviceInterface
{
    public void Action()
    {
        Debug.Log("Switch toggled.");
    }
}
