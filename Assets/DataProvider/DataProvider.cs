using System;
using System.Linq;
using UnityEngine;

namespace DataProvider
{
    [Serializable]
    public class UserData
    {
        public string name;
        public string id;
    }

    [Serializable]
    public class Address
    {
        public string street;
        public string number;
        public string postalCode;
        public string city;
        public string country;
    }

    [Serializable]
    public class PackageData
    {
        public string id;
        public double weight;
        public Address destination;
    }

    [Serializable]
    public class Data
    {
        public UserData[] loginData;
        public PackageData[] packageData;
    }

    [CreateAssetMenu(fileName = "Data", menuName = "Scripts/DataProvider", order = 1)]
    public class DataProvider : ScriptableObject
    {
        public TextAsset tInputFile;

        private Data dJSONData;

        public void Awake()
        {
            Debug.Log(tInputFile.ToString());
            dJSONData = JsonUtility.FromJson<Data>(tInputFile.ToString());
            Debug.Log(JsonUtility.ToJson(dJSONData));
        }

        public UserData FindUserById(string id)
        {
            return dJSONData.loginData.Where(t => t.id.Equals(id)).FirstOrDefault(null);
        }

        public PackageData FindPackageById(string id)
        {
            return dJSONData.packageData.Where(t => t.id.Equals(id)).FirstOrDefault(null);
        }
    }
}
