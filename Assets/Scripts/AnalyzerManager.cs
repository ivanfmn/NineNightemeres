using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzerManager : MonoBehaviour
{
    public Analyzer[] analyzers;

    public void onAddSpeed()
    {
        StartCoroutine(addSpeed());
    }
    public void startSearchGrows()
    {
        StartCoroutine(searchGrows());
    }
    IEnumerator addSpeed()
    {
        foreach (Analyzer a in analyzers)
        {
            a.goMoveandAddSpeed();
            yield return null;
        }
    }
    IEnumerator searchGrows()
    {
        foreach(Analyzer a in analyzers)
        {
            a.goMove();
            yield return null;
        }
    }

}
