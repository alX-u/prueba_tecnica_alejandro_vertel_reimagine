using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaTecnica.Models.Validadores
{
    public class CantidadMayorACeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var lista = value as IEnumerable<int>;
            if (lista == null) return false;
            return lista.All(c => c > 0);
        }
    }
}
