using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.FastTree;

using WebApplication2ML.Model;

public static class AirBnBProgram2
    {
        public static float AirBnBFunction2(ModelInput model)
        {
            // prep a single taxi trip
            var BookingSample = new ModelInput()
            {
                Neighbourhood_group =model.Neighbourhood_group,
                Neighbourhood = model.Neighbourhood,
                //Latitude=,
                //Longitude= "-9.42571",
                Room_type = model.Room_type,
                Minimum_nights = model.Minimum_nights,
                Number_of_reviews = model.Number_of_reviews,
                Reviews_per_month = model.Reviews_per_month,
                Calculated_host_listings_count = model.Calculated_host_listings_count,
                Availability_365 = model.Availability_365,
                Price = 0 // actual fare for this book = 80
            };

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(BookingSample);


            return result.Score;
        }
    }
