using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishCondition : MonoBehaviour
{
    public UnityEvent Finished;

    private bool helmet, code, called;
    
    // Update is called once per frame
    void Update()
    {
        if (!called && helmet && code)
        {
            called = true;
            Finished.Invoke();
        }
    }

    public void GrabbedHelmet()
    {
        helmet = true;
    }

    public void CodeCorrect()
    {
        code = true;
    }
}
