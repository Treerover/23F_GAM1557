using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;
using Unity.VisualScripting;

public class Cube : MonoBehaviour, IColor, IMove
{
    MouseKeyPlayerController m_Controller;

    float m_Speed = 10.0f;
    float m_JumpHeight = 5.0f;

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

        //Constantly rotates the cube
        transform.Rotate(0, 1, 0);

    }
    public void Move()
    {
        Vector3 movement = m_Controller.GetMoveInput();
        transform.position += movement * Time.fixedDeltaTime * m_Speed;
    }

    public void Jump()
    {
        //Makes player jump using physics
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * m_JumpHeight, ForceMode.VelocityChange);

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
