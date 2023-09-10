using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KGSDK.dao.crud;
using System;
using UnityEngine.UI;
using Newtonsoft.Json;
using KGSDK.dao;
using System.Linq;

public class VehicleDocTestClass : MonoBehaviour
{
    [SerializeField]
    private Text vehicleValue;
    [SerializeField]
    private VehicleCollectionDataRetriver vehicleCollectionDataRetriver;
    [SerializeField]
    private FeatureDocDatRetreiver featureDocDatRetreiver;

    public static List<String> featureIDList = new List<string>();

    public void OnSubmitClicked()
    {
        featureIDList.Clear();
        string param = vehicleValue.text.ToString();

        VehicleCollectionDataRetriver.OnVehicleCollectionReadCompleted += VehicleDataRead;
        FeatureDocDatRetreiver.OnFeatureCollectionReadCompleted += FeatureDataRead;

        vehicleCollectionDataRetriver.FetchVehicleData(
            TestAppConstants.VEHICLE_COLLECTION,
            TestAppConstants.VEHICLE_JSON,
            TestAppConstants.VEHICLE_ID,
            param);
    }

    public void VehicleDataRead(string result)
    {       
        
        if (result.Length != 0)
        {
            Debug.Log(result.Length);
            VehicleDocDAO vehicleDocDAO = JsonConvert.DeserializeObject<VehicleDocDAO>(result);
            featureIDList = vehicleDocDAO._supportedFeaturesID.ToList<String>();
            featureIDList.ForEach(id => Debug.Log(id));

            featureDocDatRetreiver.FetchFeatureData(
                TestAppConstants.Feature_COLLECTION,
                TestAppConstants.Feature_JSON,
                TestAppConstants.Feature_ID,
                featureIDList);
        }
        else
        {
            Debug.Log("Vehicle detail not present in Firestore");
        }
        VehicleCollectionDataRetriver.OnVehicleCollectionReadCompleted -= VehicleDataRead;
    }

    public void FeatureDataRead(List<string> result)
    {
        Debug.Log("Inside FeatureDataRead");

        if (result.Count != 0)
        {
            result.ForEach(id => Debug.Log(id));
        }
        else
        {
            Debug.Log("Feature not present in Firestore");
        }
        result.Clear();
        FeatureDocDatRetreiver.OnFeatureCollectionReadCompleted -= FeatureDataRead;
    }

}
