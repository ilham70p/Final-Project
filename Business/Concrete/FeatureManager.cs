using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeatureManager : IFeatureManager
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void AddFeature(Feature feature)
        {
            _featureDal.Add(feature);
        }

        public void DeleteFeature(int id)
        {
            
            _featureDal.Delete(_featureDal.Get(id));
        }

        public List<Feature> GetAllFeatures()
        {
           return _featureDal.GetAll();
        }

        public Feature GetFeature(int id)
        {
            return _featureDal.Get(id);
        }

        public void UpdateFeature(Feature feature, int Id)
        {
            Feature myfeature = _featureDal.Get(Id);
            myfeature.ABS = feature.ABS;
            myfeature.Assist=feature.Assist;
            myfeature.PowerSteering=feature.PowerSteering;
            myfeature.PowerWindow=feature.PowerWindow;
            myfeature.Cruise=feature.Cruise;
            myfeature.RearSensor=feature.RearSensor;
            myfeature.ABSAirBag=feature.ABSAirBag;
            myfeature.SteeringAdjust=feature.SteeringAdjust;
            myfeature.AirCondition=feature.AirCondition;
            myfeature.Navigation=feature.Navigation;
            myfeature.Alloy=feature.Alloy;
            myfeature.Radio = feature.Radio;
            myfeature.Immobilizer=feature.Immobilizer;
            myfeature.Locking=feature.Locking;
            myfeature.Xenon = feature.Xenon;

            _featureDal.Update(myfeature);
        }
    }
}
