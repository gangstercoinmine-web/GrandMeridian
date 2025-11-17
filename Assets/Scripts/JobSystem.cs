using UnityEngine;
using System.Collections;

public class JobSystem : MonoBehaviour
{
    public MoneySystem moneySystem;

    public void StartDeliveryJob()
    {
        StartCoroutine(DoDelivery());
    }

    IEnumerator DoDelivery()
    {
        // simulate job delay
        yield return new WaitForSeconds(5f);
        if (moneySystem != null) moneySystem.Add(50);
    }
}
