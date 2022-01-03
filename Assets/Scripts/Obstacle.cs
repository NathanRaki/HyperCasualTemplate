using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;
    private GameObject scoreText;

    public GameObject winParticles;
    public Transform winParticlesPos;

    public GameObject loseParticles;

    void Start()
    {
        scoreText = GameObject.Find("Score Text");
        try
        {
            winParticlesPos = GameObject.Find("Win Particles Position").transform;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Instantiate(loseParticles, other.gameObject.transform.position, Quaternion.identity);
            iTween.PunchScale(other.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1f);
            Destroy(other.gameObject, 0.5f);
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Invoke("ReloadLevel", 3);
        }
        if (other.gameObject.name == "Out")
        {
            if (winParticlesPos)
            {
                iTween.PunchScale(scoreText, new Vector3(2f, 2f, 2f), 0.8f);
                scoreText.GetComponent<TextMeshProUGUI>().text = (int.Parse(scoreText.GetComponent<TextMeshProUGUI>().text) + 1).ToString();
                Instantiate(winParticles, winParticlesPos.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
