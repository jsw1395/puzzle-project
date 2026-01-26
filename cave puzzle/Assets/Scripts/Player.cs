using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject obj = null;
    DeviceInterface func;
    float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(speed * Vector2.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(speed * Vector2.down * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Vector2.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Vector2.right * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(obj)
            {
                func = obj.GetComponentInParent<DeviceInterface>();
                func.Action();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever"))
        {
            obj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}
