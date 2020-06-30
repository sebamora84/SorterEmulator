using Autofac;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface IService: IStartable
    {
        void Stop();
    }
}
