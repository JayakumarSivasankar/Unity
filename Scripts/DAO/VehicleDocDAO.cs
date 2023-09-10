using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGSDK.dao
{
    [System.Serializable]
    public class VehicleDocDAO
    {
        private string vehicleId;
        private string mby;
        private int modelYear;
        private string vehicleName;
        private string[] supportedFeaturesID;
        private string vuforiaDatasetId;
        private bool isArModeAvailable;
        private bool is3DModeAvailable;
        public string _vehicleId { get => vehicleId; set => vehicleId = value; }
        public string _mby { get => mby; set => mby = value; }
        public string _vehicleName { get => vehicleName; set => vehicleName = value; }
        public string[] _supportedFeaturesID 
        { get => supportedFeaturesID; set => supportedFeaturesID = value; }
        public string _vuforiaDatasetId { get => vuforiaDatasetId; set => vuforiaDatasetId = value; }
        public bool _isArModeAvailable { get => isArModeAvailable; set => isArModeAvailable = value; }
        public bool _is3DModeAvailable { get => is3DModeAvailable; set => is3DModeAvailable = value; }
        public int _modelYear { get => modelYear; set => modelYear = value; }
    }
}
