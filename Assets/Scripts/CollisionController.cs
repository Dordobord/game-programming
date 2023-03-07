using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "box")
        {
            Debug.Log("Congratulations, you've won!");
        }
    }
}
