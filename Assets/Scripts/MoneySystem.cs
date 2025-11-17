using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public int money = 0;

    public void Add(int amount)
    {
        money += amount;
        // Hook: update UI
        Debug.Log("Money: " + money);
    }

    public bool Spend(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            Debug.Log("Money spent. Left: " + money);
            return true;
        }
        Debug.Log("Not enough money");
        return false;
    }
}
