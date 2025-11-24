using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        target = rightPoint.position;
    }

    void Update()
    {
        // Pomeri platformu ka targetu
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Kada stigne do jedne tačke - promeni smer
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == rightPoint.position)
                target = leftPoint.position;
            else
                target = rightPoint.position;
        }
    }
}
