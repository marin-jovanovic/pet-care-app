﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IdDescriptable { get; set; }
        public string UserName { get; set; }
        public int IdPetType { get; set; }
        
        public string TypePetName { get; set; }


    }
}