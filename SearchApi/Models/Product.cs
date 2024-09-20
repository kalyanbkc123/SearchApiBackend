    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;


    namespace SearchApi.Models
        {
    public class Product
    {
        public int Id { get; set; }  // Primary key for Product
        public string MainCategory { get; set; }
        public string Title { get; set; }
        public double AverageRating { get; set; }
        public int RatingNumber { get; set; }
        public List<string> Features { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Store { get; set; }
        public List<string> Categories { get; set; }
        public int ProductDetailsId { get; set; }  // Foreign key for ProductDetails
        public ProductDetails Details { get; set; }
        public string ParentAsin { get; set; }
    }

    public class ProductDetails
    {
        public int Id { get; set; }  // Primary key for ProductDetails
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Capacity { get; set; }
        public string Wattage { get; set; }
        public string Voltage { get; set; }
        public string PackageDimensions { get; set; }
        public double Weight { get; set; }
        public DateTime DateFirstAvailable { get; set; }
        public string Manufacturer { get; set; }
        public int BestSellerRankId { get; set; }  // Foreign key for BestSellerRank
        public BestSellerRank BestSellerRank { get; set; }
    }

    public class BestSellerRank
    {
        public int Id { get; set; }  // Primary key for BestSellerRank
        public string Category { get; set; }
        public int Rank { get; set; }
    }
}

    