using Firebase.Firestore;
using KGSDK.FirestoreCrud;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGSDK.dao.crud
{
    public class FeatureDocDatRetreiver : MonoBehaviour
    {
        private List<string> featuresList = new List<string>();
        public static event Action<List<string>> OnFeatureCollectionReadCompleted;
        public async void FetchFeatureData
                (string featureCollectionName, string featureJson, string featureID, List<string> queryParam)
        {
            FirestoreDataRetriverImpl firestoreDataRetriverImpl = new FirestoreDataRetriverImpl();

            await firestoreDataRetriverImpl
                .FetchDataList(featureCollectionName, featureID, queryParam).ContinueWith(task =>
                {
                    QuerySnapshot querySnapshot = task.Result;
                    foreach (DocumentSnapshot document in querySnapshot.Documents)
                    {
                        Dictionary<string, object> documentDictionary = document.ToDictionary();
                        featuresList.Add(String.Format("{0}", documentDictionary[featureJson]));
                    }

                }).ContinueWith(a =>
                {
                    if (a.IsCompleted)
                    {
                        OnFeatureCollectionReadCompleted.Invoke(featuresList);
                        featuresList.Clear();
                    }
                });

        }
    }
}