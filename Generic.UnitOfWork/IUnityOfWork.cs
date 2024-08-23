using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.UnitOfWork
{
    public interface IUnityOfWork
    {
        void SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
