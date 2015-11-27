using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.WebUI.Security.Abstract
{
    public interface IHash
    {
        System.Guid HashString(string text);
    }
}
