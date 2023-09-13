using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MyInterfaces;

public class SelectionManager : MonoBehaviour
{

    // Use this for initialization
    Color originalColor;
    void Start()
    {
        originalColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                var objects = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IColor>();
                foreach (var obj in objects)
                {
                    obj.ResetColor();
                }

                IColor IColor = hitInfo.transform.gameObject.GetComponent<IColor>();
                if (IColor != null)
                {
                    //Sets IColor to a random color
                    IColor.SetColor(new Color(Random.value, Random.value, Random.value));
                }
            }
        }
    }
}
