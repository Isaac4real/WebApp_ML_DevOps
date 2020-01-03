using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.FastTree;
using WebApplication2.ML;

using WebApplication2ML.Model;

public static class AirBnBProgram2
    {
        public static float AirBnBFunction2(int first, int second)
        {
            // prep a single taxi trip
            var BookingSample = new ModelInput()
            {
                Neighbourhood_group = "Cascais",
                Neighbourhood = "Cascais e Estoril",
                //Latitude=,
                //Longitude= "-9.42571",
                Room_type = "Entire home/apt",
                Minimum_nights = 5,
                Number_of_reviews = 30,
                Reviews_per_month = 0.53f,
                Calculated_host_listings_count = 1,
                Availability_365 = 320,
                Price = 0 // actual fare for this book = 80
            };

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(BookingSample);


            return result.Score;
        }
    }
