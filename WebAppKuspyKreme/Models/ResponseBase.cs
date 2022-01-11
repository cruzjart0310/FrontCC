using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKuspyKreme.Models
{
    public class ResponseBase<T>
    {
        public int CodeResult { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Details { get; set; }

        public string Messaje { get; set; }

        public T Element { get; set; }

        public IEnumerable<T> List { get; set; }

        public int Value { get; set; }

        public ResponseBase()
        {
            this.CodeResult = (int)System.Net.HttpStatusCode.InternalServerError;
            this.Success = false;
            this.Messaje = "Ocurrió un error al realizar la operación indicada";
            this.Details = new List<string>();
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una consulta correcta
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void ConsultaCorrecta()
        {
            this.Success = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Messaje = "Consulta realizada correctamente";
        }

        public void ConsultaNoEncontrada()
        {
            this.Success = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.NotFound;
            this.Messaje = "No se encontraron resultados con la consulta solicitada";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una creación
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void CreacionCorrecta()
        {
            this.Success = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.Created;
            this.Messaje = "Información almacenada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una eliminación
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void EliminacionCorrecta()
        {
            this.Success = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Messaje = "Información eliminada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una actualización correcta
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void ActualizacionCorrecta()
        {
            this.Success = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Messaje = "Información actualizada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminades cuando se genera un error
        /// </summary>
        /// <param name="errorCode">Código de error que regresará la api</param>
        /// <param name="mensaje">Texto del mensaje del error</param>
        /// <param name="detalles">Lista de detalles a mostrar</param>
        public void Error(int errorCode, string mensaje, IEnumerable<string> detalles)
        {
            this.Success = false;
            this.CodeResult = errorCode;
            this.Messaje = mensaje;
            this.Details = detalles;
            this.Element = default(T);
            this.List = null;
        }
    }
}