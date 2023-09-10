using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGSDK.dao
{
    public class FeatureDocDAO
    {
        private string featureid;
        private string categoryName;
        private string shortTitle;
        private string longTitle;
        private string featureDescription;
        private string featureListImageUrl;
        private string featureDetailImageUrl;
        private string featureExpandImageUrl;
        private string[] salesCodes;
        private string[] hotspotsId;
        private string searchQueryParam;
        private string type;

        public string _featureid 
        { get => featureid; set => featureid = value; }
        public string _categoryname 
        { get => categoryName; set => categoryName = value; }
        public string _shortTitle 
        { get => shortTitle; set => shortTitle = value; }
        public string _longTitle 
        { get => longTitle; set => longTitle = value; }
        public string _featureDescription 
        { get => featureDescription; set => featureDescription = value; }
        public string _featureListImageUrl 
        { get => featureListImageUrl; set => featureListImageUrl = value; }
        public string _featureDetailImageUrl 
        { get => featureDetailImageUrl; set => featureDetailImageUrl = value; }
        public string _featureExpandImageUrl 
        { get => featureExpandImageUrl; set => featureExpandImageUrl = value; }
        public string[] _salesCodes 
        { get => salesCodes; set => salesCodes = value; }
        public string[] _hotspotsId 
        { get => hotspotsId; set => hotspotsId = value; }
        public string _searchQueryParam 
        { get => searchQueryParam; set => searchQueryParam = value; }
        public string _type 
        { get => type; set => type = value; }
    }

}

