using UnityEngine;
using System.Collections;

public class SpookyFaces : MonoBehaviour {

    public GameObject GameObjectToHide;
    public float MinTime;
    public float MaxTime;

    void Start()
    {
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
    }

    IEnumerator ToggleVisibilityCo(GameObject someObj)
    {
        if (someObj == null) yield break;

        while (true)
        {
            someObj.SetActive(!someObj.active);

            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }

    }
}
