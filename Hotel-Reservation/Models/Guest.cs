﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hotel_Reservation.Models;

public partial class Guest
{
    public string Ssn { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public string Email { get; set; }

    public string ContactNumber { get; set; }

    public string Address { get; set; }

    [JsonIgnore]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}