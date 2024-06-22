namespace GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

public interface IPublishable
{
    void SendToAvailable();
    void SendToUnavailable();
    void SendToInUse();
}