using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonDetect : MonoBehaviour
{
    public GameObject fatal;
    public GameObject UI;
    private int PlayerHealth;
    private bool deathTrigger;
    private Scene scene;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == fatal.name)
        {
            PlayerHealth = 0;
            print("Triggered!!!!!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        print("Testttttttttt");
        PlayerHealth = 1;
        deathTrigger = false;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth==0 && deathTrigger == false)
        {
            deathTrigger = true;
            //triger next event
            //OnGUI();
            bool x = true;
            StartCoroutine(Reset());
            
            
        }
    }

    IEnumerator Reset()
    {
        UI.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene.buildIndex);
    }
}
