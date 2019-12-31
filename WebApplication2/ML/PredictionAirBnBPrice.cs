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

namespace WebApplication2.ML
{
    /// <summary>
    /// The Booking class represents a single book.
    /// </summary>
    public class Booking
    {
        [LoadColumn(4)] public string NeighbourhoodGroup;
        [LoadColumn(5)] public string Neighbourhood;
        //[LoadColumn(6)] public string Latitude;
        //[LoadColumn(7)] public string Longitude;
        [LoadColumn(8)] public string RoomType;
        [LoadColumn(10)] public string MinimumNights;
        [LoadColumn(11)] public float NumberOfReviews;
        [LoadColumn(12)] public float ReviewsperMonth;
        [LoadColumn(13)] public int HostListingsCount;
        [LoadColumn(14)] public int Availability365;
        [LoadColumn(9)] public float Price;
    }

    /// <summary>
    /// The bookingPricePrediction class represents a single far prediction.
    /// </summary>
    public class bookingPricePrediction
    {
        [ColumnName("Score")] public float Price;
    }
}

/// <summary>
/// The program class.
/// </summary>
public static class AirBnBProgram
{
    // file paths to data files
    static readonly string dataPath = Path.Combine(Environment.CurrentDirectory, "Data/listingsAirBnB_Lisbon.csv");

    public static float AirBnBFunction(int first, int second)
    {
        // create the machine learning context
        var mlContext = new MLContext();

        // set up the text loader 
        var textLoader = mlContext.Data.CreateTextLoader(
            new TextLoader.Options()
            {
                Separators = new[] { ',' },
                HasHeader = true,
                Columns = new[]
                {
                    new TextLoader.Column("NeighbourhoodGroup", DataKind.String, 4),
                    new TextLoader.Column("Neighbourhood", DataKind.String, 5),
                    //new TextLoader.Column("Latitude", DataKind.String, 6),
                    //new TextLoader.Column("Longitude", DataKind.String, 7),
                    new TextLoader.Column("RoomType", DataKind.String, 8),
                    new TextLoader.Column("MinimumNights", DataKind.String, 10),
                    new TextLoader.Column("NumberOfReviews", DataKind.Single, 11),
                    new TextLoader.Column("ReviewsperMonth", DataKind.Single, 12),
                    new TextLoader.Column("HostListingsCount", DataKind.Single, 13),
                    new TextLoader.Column("Availability365", DataKind.Single, 14),
                    new TextLoader.Column("Price", DataKind.Single, 9),

                }
            }
        );

        // load the data 
        //Console.Write("Loading training data....");
        var dataView = textLoader.Load(dataPath);
        //Console.WriteLine("done");

        // split into a training and test partition
        var partitions = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

        // set up a learning pipeline
        var pipeline = mlContext.Transforms.CopyColumns(
            inputColumnName: "Price",
            outputColumnName: "Label")

            // one-hot encode all text features
            .Append(mlContext.Transforms.Categorical.OneHotEncoding("NeighbourhoodGroup"))
            .Append(mlContext.Transforms.Categorical.OneHotEncoding("Neighbourhood"))
            //.Append(mlContext.Transforms.Categorical.OneHotEncoding("Latitude"))
            //.Append(mlContext.Transforms.Categorical.OneHotEncoding("Longitude"))
            .Append(mlContext.Transforms.Categorical.OneHotEncoding("RoomType"))
            .Append(mlContext.Transforms.Categorical.OneHotEncoding("MinimumNights"))

            // combine all input features into a single column 
            .Append(mlContext.Transforms.Concatenate(
                "NeighbourhoodGroup",
                "Neighbourhood",
                //"Latitude",
                //"Longitude",
                "RoomType",
                "MinimumNights",
                "NumberOfReviews",
                "ReviewsperMonth",
                "HostListingsCount",
                "Availability365"))

            // cache the data to speed up training
            .AppendCacheCheckpoint(mlContext)

            // use the fast tree learner 
            .Append(mlContext.Regression.Trainers.FastTree());

        // train the model
        //Console.Write("Training the model....");
        var model = pipeline.Fit(partitions.TrainSet);
        //Console.WriteLine("done");

        // get a set of predictions 
        Console.Write("Evaluating the model....");
        var predictions = model.Transform(partitions.TestSet);

        // get regression metrics to score the model
        var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
        Console.WriteLine("done");

        // show the metrics
        Console.WriteLine();
        Console.WriteLine($"Model metrics:");
        Console.WriteLine($"  RMSE: {metrics.RootMeanSquaredError:#.##}");
        Console.WriteLine($"  L1:   {metrics.MeanAbsoluteError:#.##}");
        Console.WriteLine($"  L2:   {metrics.MeanSquaredError:#.##}");
        Console.WriteLine();

        // create a prediction engine for one single prediction
        var predictionFunction = mlContext.Model.CreatePredictionEngine<Booking, bookingPricePrediction>(model);

        // prep a single taxi trip
        var BookingSample = new Booking()
        {
            NeighbourhoodGroup= "Cascais",
            Neighbourhood = "Cascais e Estoril",
            //Latitude=,
            //Longitude= "-9.42571",
            RoomType = "Entire home/apt",
            MinimumNights= "5",
            NumberOfReviews= 30,
            ReviewsperMonth= 0.53f,
            HostListingsCount= 1,
            Availability365= 320,
            Price = 0 // actual fare for this book = 80
        };

        // make the prediction
        var prediction = predictionFunction.Predict(BookingSample);

        // sho the prediction
        Console.WriteLine($"Single prediction:");
        Console.WriteLine($"  Predicted fare: {prediction.Price:0.####}");
        Console.WriteLine($"  Actual fare: 80");

        return prediction.Price;
    }
}

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