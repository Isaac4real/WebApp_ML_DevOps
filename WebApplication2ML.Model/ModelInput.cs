// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace WebApplication2ML.Model
{
    public class ModelInput
    {
        [ColumnName("neighbourhood_group"), LoadColumn(0)]
        public string Neighbourhood_group { get; set; }


        [ColumnName("neighbourhood"), LoadColumn(1)]
        public string Neighbourhood { get; set; }


        [ColumnName("room_type"), LoadColumn(2)]
        public string Room_type { get; set; }


        [ColumnName("price"), LoadColumn(3)]
        public float Price { get; set; }


        [ColumnName("minimum_nights"), LoadColumn(4)]
        public float Minimum_nights { get; set; }


        [ColumnName("number_of_reviews"), LoadColumn(5)]
        public float Number_of_reviews { get; set; }


        [ColumnName("reviews_per_month"), LoadColumn(6)]
        public float Reviews_per_month { get; set; }


        [ColumnName("calculated_host_listings_count"), LoadColumn(7)]
        public float Calculated_host_listings_count { get; set; }


        [ColumnName("availability_365"), LoadColumn(8)]
        public float Availability_365 { get; set; }


    }
}