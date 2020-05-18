using System;
using System.Collections.Generic;
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
        public string tourId;
        public double weight;
    }

    [Serializable]
    public class TourData
    {
        public string id;
        public Address destination;
    }

    [Serializable]
    public class Data
    {
        public UserData[] loginData;
        public PackageData[] packageData;
        public TourData[] tourData;
    }

    [CreateAssetMenu(fileName = "Data", menuName = "Scripts/DataProvider", order = 1)]
    public class DataProvider : ScriptableObject
    {
        public TextAsset tInputFile;

        private Data dJSONData;

        public void OnEnable()
        {
            dJSONData = JsonUtility.FromJson<Data>(tInputFile.ToString());
            Debug.Log(JsonUtility.ToJson(dJSONData));
        }

        public UserData FindUserById(string sUserId)
        {
            Debug.Log("Find User by UserId: " + sUserId);
            return dJSONData.loginData.FirstOrDefault(t => t.id.Equals(sUserId));
        }

        public PackageData FindPackageById(string sPackageId)
        {
            Debug.Log("Find Package by PackageId: " + sPackageId);
            return dJSONData.packageData.FirstOrDefault(t => t.id.Equals(sPackageId));
        }

        public List<PackageData> FindPackagesByTourId(string sTourId)
        {
            Debug.Log("Find Packages by TourId: " + sTourId);
            return dJSONData.packageData.Where(t => t.tourId.Equals(sTourId)).ToList();
        }

        public TourData FindTourById(string sTourId)
        {
            Debug.Log("Find Tour by TourId: " + sTourId);
            return dJSONData.tourData.FirstOrDefault(t => t.id.Equals(sTourId));
        }
    }
}
