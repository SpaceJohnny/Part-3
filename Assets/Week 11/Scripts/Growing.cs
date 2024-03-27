using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;
    public TextMeshProUGUI squareTMP;
    public TextMeshProUGUI triangleTMP;
    public TextMeshProUGUI circleTMP;
    public TextMeshProUGUI crTMP;

    public int running;
    Coroutine coroutine;

    void Start()
    {
        StartCoroutine(GrowShapes());
    }

    //dont start coroutines on every frame!
    void Update()
    {
        crTMP.text = "Coroutines running: " + running.ToString();
    }

    //getting one coroutine to wait before another one to start 
    IEnumerator GrowShapes()
    {
        running += 1;

        yield return StartCoroutine(Square());
        yield return new WaitForSeconds(1);

        coroutine = StartCoroutine(Triangle());
        Circle();

        //acts as a yield return null
        yield return coroutine;
        running -= 1;
    }

    //it grows in one frame so the game scene looks like a still image

    //corutine is used by IEnumerator 
    //needs a yield statement
    IEnumerator Square()
    {
        running += 1;

        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            square.transform.localScale = scale;
            squareTMP.text = "Square: " + scale;

            //null tells code to come back next frame
            //wait seconds is longer than null
            yield return null;
        }
        running -= 1;
    }
    IEnumerator Triangle()
    {
        running += 1;
        float size = 0;

        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            triangle.transform.localScale = scale;
            triangleTMP.text = "Triangle: " + scale;

            yield return null;
        }
        running -= 1;
    }
    void Circle()
    {
        running += 1;

        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
        }
        while (size > 0)
        {
            size -= Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
        }
        running -= 1;
    }
}
