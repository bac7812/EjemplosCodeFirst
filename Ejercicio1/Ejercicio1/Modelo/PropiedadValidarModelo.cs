using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Modelo
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public abstract class PropiedadValidarModelo : IDataErrorInfo
    {
        // Verificar el error general del modelo
        public string Error
        {
            get
            {
                return null;
            }
        }

        // Verificar errores de propiedad
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(GetType().GetProperty(columnName).GetValue(this), new ValidationContext(this) { MemberName = columnName }, validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }
    }
}
