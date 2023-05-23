using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Tilia.Interactions.Interactables.Interactables;
using UnityEngine.SceneManagement;

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

    public void ChangeZone()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator DestroyHelmet(InteractableFacade facade)
    {
        yield return new WaitUntil(() => !facade.IsGrabbed);

        yield return new WaitForSeconds(1f);
        
        Destroy(facade.gameObject);
    }
}
