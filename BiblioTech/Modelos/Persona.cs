namespace BiblioTech.Modelos
{
    /// <summary>
    /// CLASE BASE ABSTRACTA: Persona
    /// Demuestra los pilares de ABSTRACCIÓN y HERENCIA en POO.
    /// No se puede instanciar directamente (new Persona()), sino que sirve de molde
    /// para sus clases hijas: UsuarioSistema y Lector.
    /// </summary>
    public abstract class Persona
    {
        // ENCAPSULAMIENTO: Propiedades públicas con get y set
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Constructor vacío
        protected Persona()
        {
        }

        // Constructor con parámetros para inicializar los atributos comunes
        protected Persona(int id, string nombreCompleto, string documento, string email)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Documento = documento;
            Email = email;
        }

        /// <summary>
        /// POLIMORFISMO: Método virtual que cada clase hija puede sobrescribir (override)
        /// para mostrar su información de manera diferente.
        /// </summary>
        public virtual string ObtenerResumen()
        {
            return $"{NombreCompleto} (Doc: {Documento})";
        }
    }
}
