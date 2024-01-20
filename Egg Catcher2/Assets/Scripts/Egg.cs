
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.down * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Incraese scxore
            UIManager.instance.IncreaseScore();
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            // Reduce Lifes
            UIManager.instance.ReduceLife();
        }
    }
}
