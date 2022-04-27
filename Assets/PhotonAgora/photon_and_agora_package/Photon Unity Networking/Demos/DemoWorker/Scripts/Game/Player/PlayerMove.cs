using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Photon.PunBehaviour
{
    // How fast the  moves forward and back.
    public float m_Speed = 12f;
    // How fast the  turns in degrees per second.
    public float m_TurnSpeed = 180f;
    // Reference used to move.
    private Rigidbody m_Rigidbody;
    // The current value of the movement input.
    private float m_MovementInputValue;
    // The current value of the turn input.
    private float m_TurnInputValue;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        // 不能動到其他玩家
        if (!photonView.isMine)
        {
            enabled = false;
        }
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
