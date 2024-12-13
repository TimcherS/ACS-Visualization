namespace ACSVisualization.Common
{
    public interface IHandle<TEventType>
    {
        void Handle(TEventType message);
    }
}
