namespace GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

public interface IPublicActions
{
    void SentToAvailable();
    void SentToUnavailable();
    void SentToInUse();

    void SentToInReview();
}