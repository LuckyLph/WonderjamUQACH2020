using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleThroughAllColors : MonoBehaviour
{
    private SpriteRenderer render;
    private float R = 0;
    private float G = 0;
    private float B = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.render = this.GetComponent<SpriteRenderer>();
        StartCoroutine(this.cicle());
    }


    private IEnumerator cicle()
    {
        while (true)
        {
            for (this.R = 0 ; this.R < 256; this.R++)
            {
                Debug.Log(this.R);
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            for (this.B = 255; this.B > 0; this.B--)
            {
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            for (this.G = 0; this.G < 256; this.G++)
            {
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            for (this.R = 255; this.R > 0; R--)
            {
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            for (this.B = 0; this.B < 256; this.B++)
            {
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            for (this.G = 255; this.G > 0; this.G--)
            {
                this.render.color = new Color(this.R / 255, this.G / 255, this.B / 255);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }
    }


}
