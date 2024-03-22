using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nogi : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce = 7;
    public float Speed = 5;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;
    private int ypravlenie = 0;
    private int ypravlenieAtack = -1;
    private bool AtackMod = false;
    private float timer1;

    private CharacterController _characterController;
    public Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        timer1 = 15;
    }

    void Update()
    {
        Ypravlenie();
        proverkaModa();
        AtackingMode();
        CastTimer();
    }

    private void proverkaModa()
    {
        if (AtackMod == false)
        {
           _animator.SetInteger("run", ypravlenie);
        }
        if (AtackMod == true)
        {
            _animator.SetInteger("Attack", ypravlenieAtack);
        }
    }

    private void Ypravlenie()
    {
        _moveVector = Vector3.zero;
        ypravlenie = 0;
        ypravlenieAtack = 0;

        if (AtackMod == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _moveVector += transform.forward;
                ypravlenie = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _moveVector -= transform.forward;
                ypravlenie = 2;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _moveVector += transform.right;
                ypravlenie = 1;

            }
            if (Input.GetKey(KeyCode.A))
            {
                _moveVector -= transform.right;
                ypravlenie = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            {
                _fallVelocity = -JumpForce;
                _animator.SetBool("jumping", true);
            }
        }
        if (AtackMod == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _moveVector += transform.forward;
                ypravlenieAtack = 1;
            }
            //else
            if (Input.GetKey(KeyCode.S))
            {
                _moveVector -= transform.forward;
                ypravlenieAtack = 2;
            }
           //else
            if (Input.GetKey(KeyCode.D))
            {
                _moveVector += transform.right;
                ypravlenieAtack = 3;

            }
            //else
            if (Input.GetKey(KeyCode.A))
            {
                _moveVector -= transform.right;
                ypravlenieAtack = 4;
            }
            //else
            //{
                //ypravlenieAtack = 0;
            //}
            if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            {
                _fallVelocity = -JumpForce;
                _animator.SetBool("jumping", true);
            }
        }
        
    }

    void FixedUpdate()
    {
        Pritazhenie();
    }

    private void Pritazhenie()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            _animator.SetBool("jumping", false);
        }
    }
    private void AtackingMode()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            AtackMod = true;
            timer1 = 15;
        }
    }
    private void CastTimer()
    {
        if (AtackMod == true)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0f)
            {
                timer1 = 15f;
                AtackMod = false;
                _animator.SetInteger("Attack", -1);
            }
        }
    }
}