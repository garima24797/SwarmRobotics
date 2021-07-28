using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace collision_avoidance
{
    public class playermovement : MonoBehaviour
    {
        public RaycastHit hit;
        public GameObject target;
        public float speed=25,  rotsp=10;
        public float rays = 6, angle = 20,length=3;
        void Start()
        {
            target = GameObject.Find("goal");
        }
        void FixedUpdate()
        {
            Vector3 dir;
            dir = (target.transform.position - transform.position).normalized;
            for (int i = 1; i < rays; i++)
            {
                var quaternion1 = Quaternion.AngleAxis((i / rays) * angle * 2 - angle, Vector3.up) * transform.rotation;
                Vector3 direction1 = quaternion1 * Vector3.forward.normalized;
                Ray ray = new Ray(transform.position, direction1);
                if (Physics.Raycast(ray, out hit, length))
                    if (hit.collider.CompareTag("obstacle")) {
                        {
                            dir += hit.normal * rotsp;
                        }
                    }
             
                    Quaternion goal_dir = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, goal_dir, 2 * Time.deltaTime);
                    transform.position += transform.forward * speed/10 * Time.deltaTime;
                
              
            }
        }


        void OnDrawGizmos() { 
        
            Gizmos.color=Color.yellow;
            for (int i = 1; i < rays; i++)
            {
                var quaternion = Quaternion.AngleAxis((i / rays) * angle * 2 - angle, Vector3.up) * transform.rotation;
                Vector3 direction = quaternion* Vector3.forward.normalized;
                Gizmos.DrawRay(transform.position,direction*length);
                Debug.Log("ray");
            }
          
        }
    }
}
