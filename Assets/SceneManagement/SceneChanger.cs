using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void projectileMotion()
    {
        SceneManager.LoadScene("ProjectileMotion");
    }

    public void electricField()
    {
        SceneManager.LoadScene("ElectricField");
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

    public void patchNotes()
    {
        panel.SetActive(true);
    }

    public void patchNotesBack()
    {
        panel.SetActive(false);
    }

    public void quit()
    {
        quit();
    }
}
