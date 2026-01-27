using Unity.VisualScripting;
using UnityEngine;

public class GoalControl : MonoBehaviour
{
    [SerializeField] bool isPlayerGoal = false;
    [SerializeField] bool isBatGoal = false;

    public void Set(int idx)
    {
        if(idx < 7)
        {
            isBatGoal = true;
            isPlayerGoal = false;
        }
        else
        {
            isBatGoal = false;
            isPlayerGoal = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player reached goal.");
            isPlayerGoal = true;
            if(isBatGoal)
            {
                Manage.Instance.NextScene();
            }
        }
        if (collision.tag == "Bat")
        {
            Debug.Log("Bat reached goal.");
            isBatGoal = true;
            if (isPlayerGoal)
            {
                Manage.Instance.NextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player left goal.");
            isPlayerGoal = false;
        }
        if (collision.tag == "Bat")
        {
            Debug.Log("Bat left goal.");
            isBatGoal = false;
        }
    }
}
