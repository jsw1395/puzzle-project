using UnityEngine;
using UnityEngine.U2D;

public class DoorControl :  MonoBehaviour, DeviceInterface
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    [SerializeField]
    bool isOpen = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Action()
    {
        if (isOpen)
        {
            Debug.Log("Closing the door."); //문 닫는 동작, 애니메이션 추가 등
            rigid.simulated = true;
            sprite.enabled = true;
            isOpen = false;
        }
        else
        {
            Debug.Log("Opening the door."); //문 여는 동작, 애니메이션 추가 등
            rigid.simulated = false;
            sprite.enabled = false;
            isOpen = true;
        }
    }
}
