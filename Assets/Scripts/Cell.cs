using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private List<Collider2D> cellCount = new List<Collider2D>();
    public GameObject image;
    private ContactFilter2D filter2D;
    public bool isActive;
    private void Start()
    {
        GameManager.Instance.NextTurn.AddListener(() => { StartCoroutine(CheckMyState()); });
        cellCount.Clear();
        if (image.activeInHierarchy)
            isActive = true;
        else
            isActive = false;
    }

    private IEnumerator CheckMyState()
    {
        foreach (GameObject cell in GameManager.Instance.cells)
        {
            if(transform.position == cell.transform.position)
            {
                CellCounting(cell);
            }
        }

        yield return null;
        if (!isActive)
        {
            if (cellCount.Count == 3)
            {
                //Debug.Log("켜저!");
                image.SetActive(true);
                isActive = true;
            }
        }
        else
        {
            if (cellCount.Count - 1 >= 4 || cellCount.Count - 1 <= 1)
            {
                image.SetActive(false);
                isActive = false;
            }
        }
        
    }
    private void CellCounting(GameObject cell)
    {
        cellCount.Clear();
        Physics2D.OverlapCircle(cell.transform.position, 1f, filter2D, cellCount);
        //Debug.Log("이름:" + gameObject.name + "갯수:" + (cellCount.Count -1));
    }

/*    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,1f);
    }*/
}
