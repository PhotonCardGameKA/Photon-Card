using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDrapDrop : MonoBehaviour
{
    private bool isDragging = false;
    public GameObject canvas;
    public GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;
    public GameObject mDropZone;//specific moments time
    public bool isOverDropZone;
    void Start()
    {
        canvas = GameObject.Find("MainCanvas");
        dropZone = GameObject.Find("DropZone");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        isOverDropZone = true;
        mDropZone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        isOverDropZone = false;
        mDropZone = null;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }
    }
    public void StartDrag()
    {
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }
    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(mDropZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

}
