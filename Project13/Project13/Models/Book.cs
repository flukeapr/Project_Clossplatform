//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project13.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class Book
    {
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Category { get; set; }
        public string Short_Story { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Image { get; set; }

        public List<String> Categories { get; set; }
        public string SelectedCategoryText { get; set; }

       
    }
}