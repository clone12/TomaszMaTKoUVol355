using TKOU.SimAI.Interfaces;
using UnityEngine;

namespace TKOU.SimAI.Levels.Buildings
{
    /// <summary>
    /// Visualisation of the <see cref="Building"/> object.
    /// </summary>
    public class BuildingEntity : MonoBehaviour, IAmEntity
    {


        #region Properties

        public Building Building
        {
            get;
            private set;
        }

        #endregion Properties

        #region Public methods

        public static BuildingEntity SpawnEntity(Building ownerBuilding)
        {
            BuildingData buildingData = ownerBuilding.BuildingData;

            if (buildingData == null)
            {
                Debug.LogError($"Can't spawn a building, {nameof(buildingData.BuildingEntityPrefab)} is null!");

                return null;
            }

            BuildingEntity buildingEntity = Instantiate(buildingData.BuildingEntityPrefab);

            buildingEntity.Initialize(ownerBuilding);

            return buildingEntity;
        }

        private void Update()
        {
            
        }

        public void EarnMoney()
        {
            //Tutaj nalezaloby zrobic IEnumerator ktory co 5s wywolywalby się w "playerController" i za pomoca "instantitate" 
            // tworzyc na chwile tekjst "+wartosc" jako ze jest to skrypt "podpiety do kazdego budynku"
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        #endregion Public methods

        #region Private methods

        private void Initialize(Building building)
        {
            Building = building;

            transform.position = building.Tile.Position;
        }


        #endregion Private methods
    }
}