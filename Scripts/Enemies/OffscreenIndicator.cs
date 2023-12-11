using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenIndicator : MonoBehaviour
{
    public GameObject indicator;
    public Transform target;

    [SerializeField] private LayerMask raycastLayer;
    new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        target = GetComponent<EnemySeeking>().target;
        indicator.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, raycastLayer);

        if (ray.collider != null)
        {
            indicator.transform.position = ray.point;
        }
 
        if(transform.position == indicator.transform.position)
        {
            indicator.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == raycastLayer)
        {
            indicator.SetActive(false);
        }
    }
}
