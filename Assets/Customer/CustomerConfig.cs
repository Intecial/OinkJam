using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomerConfig", menuName = "Customer Config")]
public class CustomerConfig : ScriptableObject{
    public string customerName;

    public int profitMargin;

}