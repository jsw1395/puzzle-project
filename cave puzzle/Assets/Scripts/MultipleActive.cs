using System.Collections.Generic;
using UnityEngine;

public class MultipleActive : MonoBehaviour
{
    public List<GameObject> linkedDevice = new List<GameObject>();
    public List<GameObject> checkDevice = new List<GameObject>();
    public bool allActive = false;
    // Update is called once per frame
    void Update()
    {
        allActive = false;
        foreach (GameObject cDevice in checkDevice)
        {
            if(cDevice.tag == "Plate")
            {
                PlateControl plate = cDevice.GetComponent<PlateControl>();
                if (plate.isActive)
                {
                    allActive = true;
                }
            }
            else if (cDevice.tag == "Switch")
            {
                SwitchControl Switch = cDevice.GetComponent<SwitchControl>();
                if (Switch.isActive)
                {
                    allActive = true;
                }
            }
            else if (cDevice.tag == "Lever")
            {
                LeverControl lever = cDevice.GetComponent<LeverControl>();
                if (lever.isActive)
                {
                    allActive = true;
                }
            }
        }
        if (allActive)
        {
            foreach (GameObject device in linkedDevice)
            {
                DeviceInterface deviceInterface = device.GetComponent<DeviceInterface>();
                if (deviceInterface != null) 
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
}
