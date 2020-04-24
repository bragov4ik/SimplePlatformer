using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private SceneController _controller;
    [SerializeField] private CollectibleType _collectibleType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            _controller.pickUp(_collectibleType);
        }
        Destroy(this.gameObject);
    }
}

public enum CollectibleType
{
    Coin = 1,
    Key = 2
}
