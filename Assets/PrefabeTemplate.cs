using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabeTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f);

    }
}
