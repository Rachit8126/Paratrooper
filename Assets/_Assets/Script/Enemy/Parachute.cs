using System.Collections;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    [SerializeField] private float disableTime;
    [SerializeField] private GameObject parachuteObj;
    
    private void OnEnable()
    {
        parachuteObj.SetActive(true);
        StartCoroutine(DisableParachute());
    }

    private void OnDisable()
    {
        StopCoroutine(DisableParachute());
    }

    private IEnumerator DisableParachute()
    {
        yield return new WaitForSeconds(disableTime);
        parachuteObj.SetActive(false);
    }
}
