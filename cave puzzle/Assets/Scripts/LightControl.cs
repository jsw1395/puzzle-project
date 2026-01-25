using UnityEngine;

public class LightControl : MonoBehaviour, DeviceInterface
{
    [SerializeField]
    bool isOn = false;

    public void Action()
    {
        if (isOn)
        {
            Debug.Log("Light off."); //동작(검정으로 해놓고 투명도조절?)
            isOn = false;
        }
        else
        {
            Debug.Log("Light on."); //동작(검정으로 해놓고 투명도조절?)
            isOn = true;
        }
    }
}
