using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject towerElement;
    [SerializeField] private GameObject level;
    private List<TowerElementController> towerElements = new List<TowerElementController>();
    Vector3 currentMousePosition= Vector3.zero;
    private void Start()
    {
        foreach(var collision in FindObjectsOfType<ObstacleWrapperController>())
        {
            Debug.Log(collision);
            collision.CollisionEvent += RemoveTowerElement;
        }
    }

    private void Update()
    {
        currentMousePosition = Input.mousePosition;
        float screenWidth = Screen.width;
        float position = Mathf.Lerp(-2f,2f,Mathf.Clamp(currentMousePosition.x, screenWidth * 0.1f, screenWidth * 0.9f)/screenWidth);
       
        transform.position = new Vector3(transform.position.x, transform.position.y, -position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gather"))
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.AddScore(1);

            InstantiateTowerElements(other);
            AlignTowerElements();
        }

        if (other.gameObject.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.AddScore(10);
        }
    }

    private void AlignTowerElements()
    {
        foreach (var x in towerElements)
        {
            x.transform.position = new Vector3(transform.position.x, x.transform.position.y, transform.position.z);
        }
    }

    private void InstantiateTowerElements(Collider other)
    {
        for (int i = 0; i < other.gameObject.GetComponent<GatherController>().GatherAmount; i++)
        {
            character.transform.position += new Vector3(0, 1.1f, 0);
            GameObject element = Instantiate(towerElement, character.transform.position - new Vector3(0, 1.1f, 0), character.transform.rotation, transform);
            towerElements.Add(element.GetComponent<TowerElementController>());
            character.transform.position = new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
        }
    }

    public void RemoveTowerElement(int count)
    {
        if(count > towerElements.Count)
        {
            LevelManager.Instance.HasLost = true;
            LevelManager.Instance.LoadMainMenu();
            LevelManager.Instance.CurrentLevelIndex--;
            ScoreManager.Instance.AddAllTimeScore();
            return;
        }
        for (int i = 0; i < count; i++)
        {
            TowerElementController firstElement = towerElements[0];
            
            towerElements.Remove(firstElement);
            firstElement.gameObject.transform.parent = level.transform;
        }
    }
}
