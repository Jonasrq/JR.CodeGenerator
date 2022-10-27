
namespace PruebaInicial
{
    /// <summary>
    /// Estructura de la Tabla: AdminIncidencias 
	/// Empresa: Grupo Cercasa
	/// Autor: Jonás Requena
	/// Fecha: 26/10/2022
    /// </summary>
	public class AdminIncidencias
    {
        ///<summary> Gets or sets the Inc ID </summary> 
        public int IncID { get; set; }
        ///<summary> Gets or sets the Piso ID </summary> 
        public int PisoID { get; set; }
        ///<summary> Gets or sets the User ID </summary> 
        public int UserID { get; set; }
        ///<summary> Gets or sets the Fecha </summary> 
        public TimeSpan Fecha { get; set; }
        ///<summary> Gets or sets the Incidencia </summary> 
        public string Incidencia { get; set; }
        ///<summary> Gets or sets the ch Fin </summary> 
        public bool chFin { get; set; }
        ///<summary> Gets or sets the Fecha Fin </summary> 
        public TimeSpan FechaFin { get; set; }
        ///<summary> Gets or sets the Solucion </summary> 
        public string Solucion { get; set; }
        ///<summary> Gets or sets the User ID2 </summary> 
        public int UserID2 { get; set; }
        ///<summary> Gets or sets the Hora </summary> 
        public DateTime Hora { get; set; }

    }
}