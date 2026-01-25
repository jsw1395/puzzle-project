using UnityEngine;

public class StoneControl : MonoBehaviour, DeviceInterface 
{
    enum PlayerDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public void Action()
    {
        Debug.Log("Pushed stone.");
    }

    void Detect()
    {

    }

    void Move(PlayerDirection direction)
    {

    }
}


