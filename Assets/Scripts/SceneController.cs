using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private TextMesh _scoreLabel;

    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickUp(CollectibleType collectible)
    {
        switch(collectible)
        {
            case CollectibleType.Coin:
                _score++;
                _scoreLabel.text = "Score : " + _score;
                break;
            case CollectibleType.Key:
                _door.open();
                break;
        }
    }

    public IEnumerator win()
    {
        GameObject winText = new GameObject("winText");
        winText.transform.position = new Vector3(-5, 0, -10);
        winText.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        winText.AddComponent<MeshRenderer>();
        TextMesh winTextMesh = winText.AddComponent<TextMesh>();
        winTextMesh.fontSize = 300;
        winTextMesh.text = "You won!";

        yield return new WaitForSeconds(3);

        restart();
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
