﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hotel_Reservation.Models;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
}