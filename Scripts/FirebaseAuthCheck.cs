using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;

public class FirebaseAuthCheck : MonoBehaviour
{
    Firebase.FirebaseApp app;
   // VehicleDAO vehicleDAO = new VehicleDAO();
    VehicleDAOScriptableObject so;
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                UnityEngine.Debug.Log("dependencyStatus " + dependencyStatus.ToString());
                // Set a flag here to indicate whether Firebase is ready to use by your app.

                ReadFireStoreData();
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void ReadFireStoreData()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        CollectionReference usersRef = db.Collection("vehicleList");
        usersRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot snapshot = task.Result;
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Debug.Log(String.Format("User: {0}", document.Id));
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                //Debug.Log(String.Format("First: {0}", documentDictionary["vehicleName"]));
                //vehicleDAO.VehicleName = (String)documentDictionary["vehicleName"];
                //Debug.Log("vehicleDAO.VehicleName " + vehicleDAO.VehicleName);
              //  so.vehicleName = vehicleDAO.VehicleName;
            }

        });
    }
}
