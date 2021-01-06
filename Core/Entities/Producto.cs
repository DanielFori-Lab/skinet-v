namespace Core.Entities
{
    public class Producto : BaseEntity
    {
        public string Name { get; set; }
        public string  Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductoType ProductoType { get; set; }
        public int ProductoTypeId { get; set; }
        public ProductoBrand ProductoBrand { get; set; }
        public int ProductoBrandId { get; set; }
    }
}