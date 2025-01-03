﻿namespace Hotel_Reservation.Models.Validation;

public abstract class ValidationUtils
{
    public static bool ValidMobile(string mobile)
    {
        mobile = mobile
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("+", "");
        bool result = mobile.All(char.IsDigit);
        return result ? true : false;
    }
}
