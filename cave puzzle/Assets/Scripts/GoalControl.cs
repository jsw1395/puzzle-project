using UnityEngine;

public class GoalControl : MonoBehaviour
{
    [SerializeField] bool isPlayerGoal = false;
    [SerializeField] bool isBatGoal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player reached goal.");
            isPlayerGoal = true;
        }
        if (collision.tag == "Bat")
        {
            Debug.Log("Bat reached goal.");
            isBatGoal = true;
        }

        if (isPlayerGoal && collision.gameObject.CompareTag("Player"))
        {
            Manage.Instance.NextScene();
        }
        else if (isBatGoal && collision.gameObject.CompareTag("Bat"))
        {
            Manage.Instance.NextScene();
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
