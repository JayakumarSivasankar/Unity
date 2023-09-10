using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encryptor : MonoBehaviour
{
    private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    private int BlockSize = 128;
    byte[] encrypted;
    byte[] toDecrypt;
    VehicleDAOScriptableObject so;

    // Start is called before the first frame update
    void Start()
    {
        string vehcileDocument = "{\"mby\":\"mby Value\",\"vehName\":\"2021 RAMTRX1500\",\"featureDesc\":\" <b><u> Head Up Display</u></b><br><br> HUD technology has its roots in aviation: <br><br> The first iteration of the tech was seen used on British Royal Air Force(RAF) fighter planes as far back as in the 1940s, with their projected gunsights.<br><br> The tech has developed significantly since, and each subsequent generation of HUD has been able to display more information with improved clarity. <br><br> HUDs were originally designed to allow pilots to have access to all the pertinent information without having to look down at their instrument panel, hence reducing distraction and, more importantly, keeping them alive.\",\"featureIdList\":[\"f01\", \"f02\"],\"modelTargets\":[{\"mtgName\": \"rammtg\"},{\"mtgScript\":\"tailgate\"}]}";

        Encrypt("demoApp#7kG23", "Firebase@123");
    }
    private void Encrypt(string messageToEncrypt, string keyPassword)
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        List<String> encryptedStrings = new List<String>();
        SymmetricAlgorithm crypt = Aes.Create();
        HashAlgorithm hash = MD5.Create();
        crypt.BlockSize = BlockSize;
        crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(keyPassword));
        crypt.IV = IV;
        ICryptoTransform encryptor = crypt.CreateEncryptor(crypt.Key, crypt.IV);
        // Create the streams used for encryption.
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(messageToEncrypt);
                    //Write all data to the stream.

                }
                encrypted = msEncrypt.ToArray();
                string s = Convert.ToBase64String(encrypted);
                Debug.Log(Encoding.UTF8.GetString(encrypted));
                DocumentReference docRef = db.Collection("encrypted").Document("KEYS");
                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "encryptedVehDoc", s },
                    { "id", "K01" },
                };
                docRef.UpdateAsync(user).ContinueWithOnMainThread(task =>
                {
                    Debug.Log("Added data to collection.");
                });
            }
        }
    }

   
   
}
