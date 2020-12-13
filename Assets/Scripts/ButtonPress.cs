using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour
{
    public Vector2 press = new Vector2(.1f, .1f);
    Vector2 scale;
    float expectedScale;

    private void Start()
    {
        scale = new Vector2(GetComponent<RectTransform>().localScale.x, GetComponent<RectTransform>().localScale.y);
        expectedScale = GetComponent<RectTransform>().localScale.x;
    }

    void OnMouseDown()
    {
        scale.x -= press.x;
        scale.y -= press.y;
        FindObjectOfType<AudioManager>().Play(Audio.Clip.Click, 1, 0);
    }

    //void Update()
    //{
    //    scale.x += (expectedScale - scale.x) / 5;
    //    scale.y += (expectedScale - scale.y) / 5;
    //    GetComponent<RectTransform>().localScale = new Vector2(scale.x, scale.y);
    //    transform.localScale = new Vector2(scale.x, scale.y);


    //    //if (Input.GetMouseButtonDown(0))
    //    //{
    //    //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    //    //    if (hit.collider == GetComponent<BoxCollider2D>())
    //    //    {
    //    //        scale.x -= press.x;
    //    //        scale.y -= press.y;

    //    //    }
    //    //}

    //    //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
    //    //{
    //    //    if (Input.GetMouseButtonDown(0))
    //    //    {
    //    //        scale.x -= press.x;
    //    //        scale.y -= press.y;
    //    //        FindObjectOfType<AudioManager>().Play(Audio.Clip.Click, 1, 0);
    //    //    }
    //    //}

}