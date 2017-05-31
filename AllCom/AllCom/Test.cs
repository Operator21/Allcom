using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCom
{
    public class Test
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string s { get; set; }
    }
}
