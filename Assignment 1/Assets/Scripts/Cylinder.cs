using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;
using Unity.VisualScripting;

public class Cylinder : MonoBehaviour, IColor, IMove
{
    MouseKeyPlayerController m_Controller;

    float m_Speed = 10.0f;
    float m_JumpHeight = 2.0f;

    bool isSelected = false;
    void Start()
    {
        m_Controller = new MouseKeyPlayerController();
    }

    void FixedUpdate()
    {
        //If the player is selected, move
        if (IsSelected())
        {
            Move();

            //If the player isnt jumping and is on the ground, jump
            if (IsJumping() && transform.position.y < 1.4f)
            {
                Jump();
            }
        }

    }
    public void Move()
    {
        Vector3 movement = m_Controller.GetMoveInput();
        transform.position += movement * Time.fixedDeltaTime * m_Speed;
    }

    public void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * m_JumpHeight, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * .35f, ForceMode.Impulse);
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        isSelected = false;
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        isSelected = true;
    }

    bool IsSelected()
    {
        return isSelected;
    }

    bool IsJumping()
    {
        return m_Controller.IsJumping();
    }
}
