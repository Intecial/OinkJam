
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerController : MonoBehaviour
{

    BottleRandomization bottleRandomization;

    private CustomerConfig[] customerConfigs;

    private void Awake()
    {
        bottleRandomization = new BottleRandomization();
        customerConfigs = Resources.LoadAll<CustomerConfig>("Customers");
    }

    void Update()
    {
        IEnumerable<CustomerStation> candidates = Registry<CustomerStation>.All;
        foreach (CustomerStation candidate in candidates)
        {   

            if(candidate == null) continue;
            if(candidate is not Component component) continue;
            if(candidate.IsEmpty()) {
                Debug.Log("Am I sapwning Customer?");
                SpawnCustomer();
                break;
            }
        }
    }

    private void SpawnCustomer()
    {
        BottleModel bottleModel = bottleRandomization.RandomizeBottle(2);
        CustomerConfig customerConfig = customerConfigs[Random.Range(0, customerConfigs.Length)];
        CustomerModel customerModel = new CustomerModel(bottleModel, customerConfig);
        CustomerStation customerStation = Registry<CustomerStation>.Get(GetEmptyStation);
        customerStation.InitializeCustomerStation(customerModel);
    }

    private CustomerStation GetEmptyStation(IEnumerable<CustomerStation> candidates)
    {
        CustomerStation customerStation = null;

        foreach (CustomerStation candidate in candidates)
        {
            if(candidate == null) continue;
            if(candidate is not Component component) continue;
            if(candidate.IsEmpty()) {
                customerStation = candidate;
                break;
            }
            
        }
        return customerStation;
    }
}