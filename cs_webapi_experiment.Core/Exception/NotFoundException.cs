using System;
namespace cs_webapi_experiment.Core.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {
        }
    }
}
