
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerController : MonoBehaviour
{

    BottleRandomization bottleRandomization;

    private CustomerConfig[] customerConfigs;

    [SerializeField]
    private float spawnTimer = 30f;

    private float timeTick = 0f;

    private void Awake()
    {
        bottleRandomization = new BottleRandomization();
        customerConfigs = Resources.LoadAll<CustomerConfig>("Customers");
        timeTick = 10f;
    }

    void Update()
    {
        timeTick -= Time.deltaTime;
        if (timeTick <= 0)
        {
            SpawnCustomer();
            timeTick = spawnTimer;
        }
    }

    private void SpawnCustomer()
    {
        BottleModel bottleModel = bottleRandomization.RandomizeBottle(Random.Range(1,5));
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