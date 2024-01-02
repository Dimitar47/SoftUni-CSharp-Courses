using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public interface IIdentifiable
    {
        string Name { get; }
        string Id { get; }

        void CheckId(string fakeSubstring);

    }
}
