using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 targetPosition;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 5.0f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Çarptığın nesne: " + hit.collider.gameObject.name);
                Debug.Log("Çarpma noktası: " + hit.point);
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
                {
                    targetPosition = hit.point;
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            if (direction.magnitude < 0.1f)
            {
                isMoving = false;
            }
            else
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
                transform.forward = direction.normalized;
            }
        }
    }
}
