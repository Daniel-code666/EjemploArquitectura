namespace WebApi
{
    public static class ServerSettings
    {
        /// <summary>
        /// Horas de desfase con el servidor.
        /// </summary>
        public static TimeSpan Desfase { get; set; }

        /// <summary>
        /// Devuelve la fecha real del servicio.
        /// </summary>
        /// <returns>Fecha real del servicio.</returns>
        public static DateTime ObtenerFechaReal()
        {
            try
            {
                return DateTime.Now.Add(-Desfase);
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}
