using UnityEngine;

public class LightControl : MonoBehaviour, DeviceInterface
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;

    [SerializeField]
    bool isOn = false;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Action()
    {
        if (isOn)
        {
            Debug.Log("Light off."); //동작(검정으로 해놓고 투명도조절?)
            rigid.simulated = true;
            sprite.enabled = true;
            isOn = false;
        }
        else
        {
            Debug.Log("Light on."); //동작(검정으로 해놓고 투명도조절?)
            rigid.simulated = false;
            sprite.enabled = false;
            isOn = true;
        }
    }
}
