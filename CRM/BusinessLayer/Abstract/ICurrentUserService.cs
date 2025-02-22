using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICurrentUserService
    {
        string UserName { get; }
        string UserRole { get; }
        int UserId { get; }
    }
}
