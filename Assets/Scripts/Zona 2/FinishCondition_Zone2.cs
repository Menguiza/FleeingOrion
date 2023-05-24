using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinishCondition_Zone2 : MonoBehaviour
{
    [SerializeField] private TMP_Text message;

    private int pipeCount;
    private bool correctPressed, called;
    
    public UnityEvent BottonPressed;

    public void Update()
    {
        if (pipeCount >= 3 && correctPressed && !called)
        {
            called = true;
            SceneManager.LoadScene(2);
        }
    }

    public void PipeSet()
    {
        pipeCount++;
    }

    public void Correct()
    {
        BottonPressed.Invoke();
        correctPressed = true;
        message.text = "Combustible cargado!";
    }

    public void Wrong()
    {
        BottonPressed.Invoke();
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        message.text = "La cagaste payaso!";

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
