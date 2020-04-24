using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    [SerializeField] private SceneController _controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            _controller.StartCoroutine(_controller.win());
        }
        Destroy(this.gameObject);
    }
}
