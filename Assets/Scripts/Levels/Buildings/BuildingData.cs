using TKOU.SimAI.Interfaces;
using UnityEngine;

namespace TKOU.SimAI.Levels.Buildings
{
    /// <summary>
    /// Data of a single building.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(BuildingData), menuName = nameof(SimAI) + "/" + nameof(SimAI.Levels) + "/" + nameof(BuildingData))]
    public class BuildingData : ScriptableObject, IAmData
    {
        #region Properties

        [field: SerializeField]
        public Sprite BuildingSprite
        {
            get;
            private set;
        }

        [field: SerializeField]
        public string BuildingName
        {
            get;
            private set;
        }

        [field: SerializeField]
        public int BuildingPrice
        {
            get;
            private set;
            // buildingprice = Random.Range(50,150);
            // nie mogłem się do końca odnaleźć w tym
            // zrobiłem wiecej "dataBuilding" ale czas nagli
        }

        [field: SerializeField]
        public BuildingEntity BuildingEntityPrefab
        {
            get;
            private set;
        }

        Sprite IAmData.DataIcon
        {
            get
            {
                return BuildingSprite;
            }
        }

        string IAmData.DataName
        {
            get
            {
                return BuildingName;
            }
        }

        IAmEntity IAmData.EntityPrefab
        {
            get
            {
                return BuildingEntityPrefab;
            }
        }

        #endregion Properties
    }
}