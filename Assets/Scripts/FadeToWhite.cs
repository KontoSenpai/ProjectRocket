using UnityEngine;
using System.Collections;

public class FadeToWhite : MonoBehaviour {

    public float fadeSpeed = 1.5f;

    private bool b_fadeToWhite = false;
    private bool b_fadeToClear = false;

    void Update()
    {
        if(b_fadeToWhite)
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.white, fadeSpeed * Time.deltaTime);
        else if (b_fadeToClear)
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    public void fadeToWhite()
    {
        b_fadeToWhite = true;
        if (b_fadeToClear)
            b_fadeToClear = false;
    }

    public void fadeToClear()
    {
        b_fadeToClear = true;
        if (b_fadeToWhite)
            b_fadeToWhite = false;
    }
}
