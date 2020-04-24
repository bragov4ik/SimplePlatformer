using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SceneController _controller;

    public float speed = 250f;
    public float jumpCoolDown = 1f;
    public float jumpForce = 12f;

    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    private float lastJump;
    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        lastJump = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            // calculate velocity
            float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, _body.velocity.y);

            // work with sprite (animation/direction)
            _anim.SetFloat("Speed", Mathf.Abs(deltaX));
            if (!Mathf.Approximately(deltaX, 0))
            {
                transform.localScale = new Vector3(
                    Mathf.Sign(deltaX) * Math.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                    );
            }

            // check if the character is on the ground
            Vector2 min = _box.bounds.min;
            Vector2 max = _box.bounds.max;
            Vector2 corner1 = new Vector2(min.x, min.y - .1f);
            Vector2 corner2 = new Vector2(max.x, min.y - .2f);
            Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
            bool onGround = true;
            if (hit == null)
            {
                onGround = false;
            }

            // do jump
            if (Input.GetKey(KeyCode.Space) && onGround && Time.time - lastJump >= jumpCoolDown)
            {
                _body.velocity = new Vector2(_body.velocity.x, jumpForce);
                lastJump = Time.time;
            }
        }
    }

    public void Die()
    {
        if (!isDead)
        {
            StartCoroutine(_Die());
        }
    }
    IEnumerator _Die()
    {
        isDead = true;
        _body.velocity = Vector2.zero;

        _anim.SetTrigger("Die");
        yield return new WaitForSeconds(2);
        _controller.restart();
    }
}
