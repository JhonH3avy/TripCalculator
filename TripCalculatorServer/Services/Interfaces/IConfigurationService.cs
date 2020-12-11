using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IConfigurationService
    {
        T GatValueInSection<T>(string sectionKey, string key);
    }
}
