using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    public float speed;
    public UnityEvent NextTurn;
    public List<GameObject> cells = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(NextTurnCo());
    }

    public IEnumerator NextTurnCo()
    {
        while(true)
        {
            NextTurn.Invoke();
            yield return new WaitForSeconds(speed);
        }
    }
}
