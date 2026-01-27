using UnityEngine;

public class StoneControl : MonoBehaviour
{
    Rigidbody2D rigid;
    RigidbodyConstraints2D originalConst;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalConst = rigid.constraints;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bat"))
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.collider.CompareTag("Stone"))
        {
            if (collision.collider.CompareTag("Player"))
            {
                rigid.constraints = rigid.constraints = originalConst;
            }
            else
            {
                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        if (collision.collider.CompareTag("Slide"))
        {
            Debug.Log("±¼·¯°¨.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bat") || collision.collider.CompareTag("Stone"))
        {
            rigid.constraints = originalConst;
        }
        if (collision.collider.CompareTag("Slide"))
        {
            Debug.Log("Á¤Áö");
        }
    }
}


