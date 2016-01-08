using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhotonModel.EntityOperators;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountOp.CreatAccout("xiezaikui", "123456");
            Console.WriteLine("成功！");
        }
    }
}
