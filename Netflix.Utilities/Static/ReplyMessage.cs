using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Utilities.Static
{
    public class ReplyMessage
    {
        public const string MESSAGE_QUERY = "Consulta exitosa";
        public const string MESSAGE_EMPTY = "No se encontraron registros";
        public const string MESSAGE_INSERT = "Registro insertado correctamente";
        public const string MESSAGE_UPDATE = "Registro actualizado correctamente";
        public const string MESSAGE_DELETE = "Registro eliminado correctamente";
        public const string MESSAGE_EXIST = "El registro ya existe";
        public const string MESSAGE_ACTIVE = "Registro activado correctamente";
        public const string MESSAGE_TOKEN = "Token generado correctamente";
        public const string MESSAGE_ERROR_VALIDATION = "Error de validación";
        public const string MESSAGE_FAILED = "Error al procesar la solicitud";
    }
}