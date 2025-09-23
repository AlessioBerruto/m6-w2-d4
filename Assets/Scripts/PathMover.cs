using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    private int currentIndex = 0;
    private int direction = 1;

    void Update()
    {
        if (waypoints.Length < 2) return;

        Transform target = waypoints[currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex += direction;

            if (currentIndex >= waypoints.Length)
            {
                direction = -1;
                currentIndex = waypoints.Length - 2;
            }
            else if (currentIndex < 0)
            {
                direction = 1;
                currentIndex = 1;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}
