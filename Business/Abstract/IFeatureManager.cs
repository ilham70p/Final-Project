using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureManager
    {
        List<Feature> GetAllFeatures();
        Feature GetFeature(int id); 
        void AddFeature(Feature feature);
        void UpdateFeature(Feature feature,int Id);
        void DeleteFeature(int id);
    }
}
