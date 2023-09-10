using Firebase.Firestore;
using KGSDK.FirestoreCrud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace KGSDK.dao.crud
{
    public class VehicleCollectionDataRetriver : MonoBehaviour
    {
        private String vehicleDetail = String.Empty;
        public static event Action<string> OnVehicleCollectionReadCompleted;
        public async void FetchVehicleData
            (string vehicleCollectionName, string vehicleJson, string vehicleID, string queryParam)
        {
            FirestoreDataRetriverImpl firestoreDataRetriverImpl = new FirestoreDataRetriverImpl();

            await firestoreDataRetriverImpl
                .FetchDataItem(vehicleCollectionName, vehicleID, queryParam).ContinueWith(task =>
                {
                    QuerySnapshot querySnapshot = task.Result;
                    foreach (DocumentSnapshot document in querySnapshot.Documents)
                    {
                        Dictionary<string, object> documentDictionary = document.ToDictionary();
                        vehicleDetail = String.Format("{0}", documentDictionary[vehicleJson]);
                    }

                }).ContinueWith(a => 
                { if (a.IsCompleted)
                    {
                        OnVehicleCollectionReadCompleted.Invoke(vehicleDetail);
                        vehicleDetail = String.Empty;
                    }
                });
            
        }        
    }

}