using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public interface IDocument
    {
        string DocType { get; set;}
        int DocID { get; set;}
    }
}
