using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductFile
    {
        public int Id{ get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public int FileType{ get; set; }
        public string FileFormat { get; set; }
        public string Path{ get; set; }
        public int FileSize { get; set; }
        public string FileName{ get; set; }
        public TimeSpan? FileTime { get; set; }
        public DateTime CreationDate{ get; set; }
        public int DisplayOrder{ get; set; }
        public int? ParentId { get; set; }
        public Product Product { get; set; }

        public ProductFile Parent{ get; set; }
        public ICollection<ProductFile> ProductFiles { get; set; }
        public ICollection<ProductFileNarrator> ProductFileNarrators { get; set; }
    }
}
