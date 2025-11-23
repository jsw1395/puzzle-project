using UnityEngine;

public class DoorControl : AbstractDevice
{
    bool isOpen = false;

    public override void Action()
    {
        if (isOpen)
        {
            Debug.Log("Closing the door.");
            isOpen = false;
        }
        else
        {
            Debug.Log("Opening the door.");
            isOpen = true;
        }
    }
    public override void Interaction()
    {
        return;
    }
}
