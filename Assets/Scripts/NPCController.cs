using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public float walkRadius = 8f;
    public float speed = 1.5f;
    Vector3 basePos;
    Vector3 targetPos;
    bool moving = false;

    void Start()
    {
        basePos = transform.position;
        StartCoroutine(AIWalk());
    }

    IEnumerator AIWalk()
    {
        while (true)
        {
            // pick a random point
            targetPos = basePos + new Vector3(Random.Range(-walkRadius, walkRadius), 0f, Random.Range(-walkRadius, walkRadius));
            moving = true;
            while (Vector3.Distance(transform.position, targetPos) > 0.5f)
            {
                Vector3 dir = (targetPos - transform.position).normalized;
                transform.position += dir * speed * Time.deltaTime;
                transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 5f);
                yield return null;
            }
            moving = false;
            // idle for random seconds
            yield return new WaitForSeconds(Random.Range(2f, 6f));
        }
    }
}
