using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);

        if (Vector3.Distance(target.position, transform.position) < 0.4f)
        {
            MoveToNextPoint();
        }

    }

    void MoveToNextPoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject); //when enemy reaches the end, we destroy the enemy object
            return;
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];

    }
}
