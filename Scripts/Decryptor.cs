
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class Decryptor : MonoBehaviour
{
    private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    private int BlockSize = 128;
   // public VehicleDAOScriptableObject so;
    public TMP_Text feature;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("Inside decryptor start");
       // FirebaseDataRetriever.OnReadCompleted += TriggerDecrypt;
        
    }

    private void TriggerDecrypt()
    {
        Debug.Log("Inside TriggerDecrypt");
        //name = so.vehicleName;
        Byte[] b = Convert.FromBase64String(AppDataManager.vehicleDocumentToDecrypt);    
        Decrypt(b, "Firebase@123");
    }

    private void Decrypt(byte[] cipherText, string keyPassword)
    {
        SymmetricAlgorithm decrypt = Aes.Create();
        HashAlgorithm hash = MD5.Create();
        decrypt.BlockSize = BlockSize;
        decrypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(keyPassword));
        decrypt.IV = IV;
        ICryptoTransform decryptor = decrypt.CreateDecryptor(decrypt.Key, decrypt.IV);

        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    String s = srDecrypt.ReadToEnd();
                    Debug.Log(s);
                    setObjectValues(s);
                }
            }
        }

        
    }

    private void setObjectValues(String s)
    {
        //AppDataManager.vehicleObj = JsonConvert.DeserializeObject<Vehicle>(s);
        //Debug.Log("mby " + AppDataManager.vehicleObj.Mby);
        //AppDataManager.vehicleObj.ModelTargets.ForEach(target =>
        //{
        //    foreach (var kvp in target)
        //    {
        //        Debug.Log(kvp.Key + ": " + kvp.Value);
        //    }
        //});
        //feature.text = AppDataManager.vehicleObj.FeatureDesc;
    }
}
