using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class CheckValidYearAttribute : ValidationAttribute
    {
        public CheckValidYearAttribute()
        {
            ErrorMessage = "El año debe ser mayor o igual a 2000";
        }
        public override bool IsValid(object value)
        {

            DateTime date = new DateTime(2000);
            var fechaValidar = (DateTime)value;
            if (fechaValidar < date)
            {
                return false;
            }
            return true;
        }
    }
}
