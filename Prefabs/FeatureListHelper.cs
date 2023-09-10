using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatureListHelper : MonoBehaviour
{

    [SerializeField]
    private Text featureTileText;

    public void SetFeatureTitle(string featureName)
    {
        featureTileText.text = featureName;
    }
}
