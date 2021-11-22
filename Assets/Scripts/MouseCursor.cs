using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        this.gameObject.transform.position = Utilities.ScreenToWorld(Camera.main,Input.mousePosition);
    }

}
