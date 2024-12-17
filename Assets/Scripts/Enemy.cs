using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public Path path;
        public int index = 0;
        public float speed = 1f;
        public int damage = 1;

        void Start()
        {
            // Find path
            path = FindObjectOfType<Path>();
            // we use a Coroutine instead of Update()
            // it spreads out the execution of that method
            // across several frames in sequential order.
            StartCoroutine(FollowPath());  
        }

        IEnumerator FollowPath()
        {
            Vector3 target;
            while (path.TryGetPoint(index, out target))
            {
                Vector3 start = transform.position;
                // Mathf.Min returns the smaller of two or more values
                // Finds out the maxDistance to move in a single move 
                // we won't overshoot our target this way
                float maxDistance = Mathf.Min(speed * Time.deltaTime, (target - start).magnitude);
                transform.position = Vector3.MoveTowards(start, target, maxDistance);

                // Rotate towards next point
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target - start), 0.05f);

                if (transform.position == target) index++;
                // we need the yield for coroutines; it will wait until
                // the next frame and start at the top of the loop
                yield return null;
            }
            // Damage player at the end of the path
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                Health.TryDamage(player.gameObject, damage);
                Destroy(gameObject);
            }


        }
    }
}

