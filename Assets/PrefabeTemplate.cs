using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabeTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // I wrote this line
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f);

        if (transform.position.y > 2)
            Destroy(gameObject);
    }
}
