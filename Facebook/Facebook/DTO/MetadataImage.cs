using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DTO
{
    public class MetadataImage
    {
        public string Path { get; set; }

        public DateTime CreatedAt { get; set; }

        public String Own { get; set; }

        public string FromPost { get; set; }
    }
}
