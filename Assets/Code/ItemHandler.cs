using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemHandler : MonoBehaviour
{
    public TextMeshProUGUI ItemScore;
    public int totalItemNumber;


    public TextMeshProUGUI FoundText;
    private List<GameObject> ItemList = new List<GameObject>();
    public GameObject GameoverScreen;
   
    void Start()
    {
        ItemScore.text = ItemList.Count + "/" + totalItemNumber;
    }

  
    void Update()
    {
        
    }
    public void UpdateItemScore( GameObject obj)
    {
        ItemList.Add(obj);
        obj.SetActive(false);
        ItemScore.text = ItemList.Count + "/" + totalItemNumber;
        StartCoroutine(ShowItemFoundText(obj));
        if(ItemList.Count==totalItemNumber)
        {
            GameoverScreen.SetActive(true);
        }

    }
    IEnumerator ShowItemFoundText(GameObject obj)
    {
        FoundText.text = obj.GetComponent<JoyItem>().Description;
        FoundText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        FoundText.gameObject.SetActive(false);
    }
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
